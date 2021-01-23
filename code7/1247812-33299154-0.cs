    [Test]
    public void FailingTestSoonToPass()
    {
        var recordToTest = new Record { P1 = 1.0, P2 = 100 };
        var recordToCompareWith = new Record { P1 = 1.0, P2 = 99.99999999 };
        Assert.That(recordToTest.P1, Is.EqualTo(recordToCompareWith.P1)recordToCompareWith.P1);
        Assert.That(recordToTest.P2, Is.EqualTo(recordToCompareWith.P2).Within(.0001));
    }
