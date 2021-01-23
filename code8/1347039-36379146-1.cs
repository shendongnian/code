    TestCaseData[] MySource = {
        new TestCaseData(new [] { "some text asdf" },
                         5, 0, 9, 0,
                         "some  asdf",
                         new int[0]),
        new TestCaseData(new [] { "some text", "", "totally unimportant texttext that stays" },
                         0, 0, 24, 2
                         "text that stays",
                         new [] { 0, 1, 2})};
    [TestCaseSource("MySource")]
    public void ShouldRemoveSelectedText(..
