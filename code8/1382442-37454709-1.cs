    [TestMethod]
    public void DifferentResultsOnEachInvocation()
    {
        var results = new[] {
                        new Result(1),
                        new Result(2),
                        new Result(3)
                    };
        var index = 0;
        var mockPayment = new Mock<IPayment>();
        mockPayment.Setup(mk => mk.ProcessPayment()).Returns(()=>results[index++]);
        var res = mockPayment.Object.ProcessPayment();
        Assert.AreEqual(1, res.Id);
        res = mockPayment.Object.ProcessPayment();
        Assert.AreEqual(2, res.Id);
        res = mockPayment.Object.ProcessPayment();
        Assert.AreEqual(3, res.Id);
    }
