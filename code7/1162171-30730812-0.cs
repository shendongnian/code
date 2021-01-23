    [Test]
    [TestCaseSource("Test1Source")]
    public void Test1(string a, string b, string c) {
    }
    [Test]
    [TestCaseSource("Test2Source")]
    public void Test2(string a, string b, string c) {
    }
    public IEnumerable Test1Source() {
        return GetCases("Test1");
    }
    public IEnumerable Test2Source() {
        return GetCases("Test2");
    }
    public IEnumerable GetCases(string testName) {
        var cases = new List<IEnumerable>();
        var lines = File.ReadAllLines(@"cases.txt").Where(x => x.StartsWith(testName));
        foreach (var line in lines) {
            var args = line.Split(',');
            var currentcase = new List<object>();
            for (var i = 1; i < args.Count(); i++) {
                currentcase.Add(args[i]);
            }
            cases.Add(currentcase.ToArray());
        }
        return cases;
    }
