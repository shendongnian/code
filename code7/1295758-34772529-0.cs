        [TestMethod]
        public void When_BothPropertiesAreSet_SuccessResult()
        {
            var mockModel = new Mock<ISomeModel>();
            mockModel.Setup(m => m.SomeProperty).Returns("something");
            var attribute = new OptionalIfAttribute("SomeProperty");
            var context = new ValidationContext(mockModel.Object, null, null);
            
            var result = attribute.IsValid(string.Empty, context);
            Assert.AreEqual(ValidationResult.Success, result);
        }
        [TestMethod]
        public void When_SecondPropertyIsNotSet_ErrorResult()
        {
            const string ExpectedErrorMessage = "Whoops!";
            var mockModel = new Mock<ISomeModel>();
            mockModel.Setup(m => m.SomeProperty).Returns((string)null);
            var attribute = new OptionalIfAttribute("SomeProperty");
            attribute.ErrorMessage = ExpectedErrorMessage;
            var context = new ValidationContext(mockModel.Object, null, null);
            var result = attribute.IsValid(string.Empty, context);
            Assert.AreEqual(ExpectedErrorMessage, result.ErrorMessage);
        }
