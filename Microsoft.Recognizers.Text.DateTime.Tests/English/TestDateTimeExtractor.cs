﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Recognizers.Text.DateTime.English.Tests
{
    [TestClass]
    public class TestDateTimeExtractor
    {
        private readonly BaseDateTimeExtractor extractor = new BaseDateTimeExtractor(new EnglishDateTimeExtractorConfiguration());

        public void BasicTest(string text, int start, int length)
        {
            var results = extractor.Extract(text);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(start, results[0].Start);
            Assert.AreEqual(length, results[0].Length);
            Assert.AreEqual(Constants.SYS_DATETIME_DATETIME, results[0].Type);
        }

        [TestMethod]
        public void TestDateTimeExtract()
        {
            BasicTest("I'll go back now", 13, 3);
            BasicTest("I'll go back as soon as possible", 13, 19);
            BasicTest("I'll go back right now", 13, 9);
            BasicTest("I'll go back on 15 at 8:00", 16, 10);
            BasicTest("I'll go back on 15 at 8:00:30", 16, 13);
            BasicTest("I'll go back on 15, 8pm", 16, 7);
            BasicTest("I'll go back 04/21/2016, 8:00pm", 13, 18);
            BasicTest("I'll go back 04/21/2016, 8:00:13pm", 13, 21);
            BasicTest("I'll go back Oct. 23 at seven", 13, 16);
            BasicTest("I'll go back October 14 8:00am", 13, 17);
            BasicTest("I'll go back October 14 8:00:00am", 13, 20);
            BasicTest("I'll go back October 14, 8:00am", 13, 18);
            BasicTest("I'll go back October 14, 8:00:01am", 13, 21);
            BasicTest("I'll go back tomorrow 8:00am", 13, 15);
            BasicTest("I'll go back tomorrow around 8:00am", 13, 22);
            BasicTest("I'll go back tomorrow for 8:00am", 13, 19);
            BasicTest("I'll go back tomorrow 8:00:05am", 13, 18);
            BasicTest("I'll go back next friday at half past 3 ", 13, 26);
            BasicTest("I'll go back May 5, 2016, 20 min past eight in the evening", 13, 45);

            BasicTest("I'll go back 8pm on 15", 13, 9);
            BasicTest("I'll go back at seven on 15", 16, 11);
            BasicTest("I'll go back 8pm next sunday", 13, 15);
            BasicTest("I'll go back 8pm today", 13, 9);
            BasicTest("I'll go back a quarter to seven tomorrow", 13, 27);
            BasicTest("I'll go back 19:00, 2016-12-22", 13, 17);
            BasicTest("I'll go back seven o'clock tomorrow", 13, 22);

            BasicTest("I'll go back tomorrow morning at 7", 13, 21);
            //BasicTestFuture("I'll go back Oct. 5 in the afternoon at 7", 13, 28);
            BasicTest("I'll go back 7:00 on Sunday afternoon", 13, 24);
            BasicTest("I'll go back twenty minutes past five tomorrow morning", 13, 41);
            BasicTest("I'll go back October 14 8:00, October 14", 13, 15);
            BasicTest("I'll go back 7, this morning", 13, 15);
            BasicTest("I'll go back tonight for 8", 13, 13);

            BasicTest("I'll go back 8pm in the evening, Monday", 13, 26);
            BasicTest("I'll go back 8pm in the evening, 1st Jan", 13, 27);
            BasicTest("I'll go back 8pm in the evening, 1 Jan", 13, 25);
            BasicTest("I'll go back 10pm tonight", 13, 12);
            BasicTest("I'll go back 8am this morning", 13, 16);
            BasicTest("I'll go back 8pm this evening", 13, 16);

            BasicTest("I'll go back this morning at 7", 13, 17);
            BasicTest("I'll go back this morning at 7pm", 13, 19);
            BasicTest("I'll go back this morning at seven", 13, 21);
            BasicTest("I'll go back this morning at 7:00", 13, 20);
            BasicTest("I'll go back this night at 7", 13, 15);
            BasicTest("I'll go back tonight at 7", 13, 12);
            BasicTest("for 2 people tonight at 9:30 pm", 13, 18);
            BasicTest("for 2 people tonight at 9:30:31 pm", 13, 21);

            BasicTest("I'll go back the end of the day", 13, 18);
            BasicTest("I'll go back end of tomorrow", 13, 15);
            BasicTest("I'll go back end of the sunday", 13, 17);

            BasicTest("I'll go back at 5th at 4 a.m.", 16, 13);

            BasicTest("I'll go back 2016-12-16T12:23:59", 13, 19);
        }
    }
}