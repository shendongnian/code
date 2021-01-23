    [TestCaseSource("SomeMethodSource")]
    public void TestSomeStuff(int x, int y, string text) {
    }
    private IEnumerable SomeMethodSource() {
        int someValue = 1;
        return new object[] {
            new object [] {someValue++,2, "Case1"},
            new object [] {someValue++,5, "Case2"}
        };
    }
