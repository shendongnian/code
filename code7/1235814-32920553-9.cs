        public interface HwsysManager
        {
            int OpenConfiguration(string hwPath);
        }
         public void TestMethod()
        {
          Mock<HwsysManager> hwsysManager = new Mock<HwsysManager>();
          hwsysManager.Setup(x => x.OpenConfiguration(It.IsAny<string>())).Returns(10);
        }
