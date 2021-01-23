    [TestClass]
    public class StringTest
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void RewriteString()
        {
            var str = "THIS\tIS\tA\tSTRING\n"+
                "THAT\tI\tWANT\tTO\n"+
                "CHANGE\tIT\tBY\tOTHER";
            var arry1 = str.Split('\n');
            var arry2 = arry1[0].Split('\t');
            arry2[0] = "NOTHING";
            arry1[0] = string.Join("\t", arry2);
            str = string.Join("\n", arry1);
            TestContext.WriteLine(str);
        }
    }
     Test Name:	RewriteString
     Test Outcome:	Passed
     Result StandardOutput:	TestContext Messages:
     NOTHING	IS	A	STRING
     THAT	I	WANT	TO
     CHANGE	IT	BY	OTHER
