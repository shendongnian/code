    [TestCase(new [] { "some text asdf" },
              5, 0, 9, 0,
              "some  asdf",
              new int[0])]
    [TestCase(new [] { "some text", "", "totally unimportant texttext that stays" },
              0, 0, 24, 2,
              "text that stays",
              new [] {0, 1, 2})]
    public void ShouldRemoveSelectedText(...
