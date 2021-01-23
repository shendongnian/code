    [TestMethod]
    [DataRow(1, 1, 2)]
    [DataRow(3, 3, 6)]
    [DataRow(9, -4, 5)]
    public void AdditionTest(int first, int second, int expected) {
      var sum = first+second;
      Assert.AreEqual<int>(expected, sum);
    }
