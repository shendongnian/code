    public class UnitTest1
    {
        [TestMethod]
        public static void TestMethod1()
        {
            SerializingLearn.Articles s = new SerializingLearn.Articles();
            s.sTitle = "a";
            s.sText = "b";
            s.sAuthor = "c";
            s.serialize(@"c:\124.txt");
        }
        [TestMethod]
        public static void TestMethod2()
        {
            SerializingLearn.Articles s = new SerializingLearn.Articles();
            s.sTitle = "a1";
            s.sText = "b1";
            s.sAuthor = "c1";
            s.serialize(@"c:\154.txt");
        }
    }
