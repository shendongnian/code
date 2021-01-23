    [TestClass]
    public class StringTest
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void RewriteString()
        {
            var str = "Garry\t19\tMale\tNoob\n" +
                "Joe\t25\tMale\tMedium\n" +
                "Gary\t33\tFemale\tExpert";
            var rows = str.Split('\n');
            var columns = rows[0].Split('\t');
            columns[0] = "Jerry";
            rows[0] = string.Join("\t", columns);
            str = string.Join("\n", rows);
            TestContext.WriteLine(str);
        }
    }
     Test Name:	RewriteString
     Test Outcome:	Passed
     Result StandardOutput:	TestContext Messages:
     Jerry	19	Male	Noob
     Joe	25	Male	Medium
     Gary	33	Female	Expert
