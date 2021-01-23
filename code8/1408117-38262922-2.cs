    string MethodToTest(string y) {
        return y != /* whatever your condition is */ ? y : string.empty
    }
    [Test]
    public void Test1() {
        Assert.AreEqual(MethodToTest("PassingCondition"), "PassingCondition");
    }
    [Test]
    public void Test2() {
        Assert.AreEqual(MethodToTest("NotPassingCondition"), string.empty);
    }
