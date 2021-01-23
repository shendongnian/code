        public void TestMethod()
        {
            Mock<HWSysManager> hwSysManager = new Mock<HWSysManager>();
            hwSysManager.Setup(x => x.ExampleReturnInMethod(It.IsAny<int> ())).Returns(10); //if parameter is any of int, return 10 in this case
        }
