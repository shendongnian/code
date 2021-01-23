    [TestMethod]
    public void TestMethod1() {
        int a = 5;
        int b = 10;
        int expected = 50;
        Mock<WebForm1> mockWebForm = new Mock<WebForm1>();
        mockWebForm.Setup(x => x.Multi(a, b)).Returns(expected);
        var webForm = mockWebForm.Object;
        var data = webForm.Multi(a, b);
        Assert.AreEqual(50, data);
    }
