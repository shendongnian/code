        [TestMethod]
        public void SaveForWeb_WhenGameControllerIsOk_DoesNotThrowException()
        {
            // Arrange
            var controller = FakeSaveLoadGameDataController();
            // Act
            controller.SaveForWeb();
            // Assert - Will fail by exceptionThrown
        }
        [TestMethod, ExpectedException(typeof(ReallyBadException))]
        public void SaveForWeb_WhenGameControllerThrowsException_ThrowsException()
        {
            // Arrange
            var controller = new FakeSaveLoadGameDataControllerWithException();
            // Act
            controller.SaveForWeb();
        }
