        [TestMethod]
        public void GetProfileImageTest()
        {
            // Arrange
            var byteArray = new[] {(byte) 12, (byte) 13};
            var image = new Mock<IWebImage>();
            var factory = new Mock<IWebImageFactory>();
            var companyService = new Mock<ICompanyService>();
            companyService.Setup(c => c.GetProfileImage(99)).Returns(byteArray);
            factory.Setup(f => f.Get(byteArray)).Returns(image.Object);
            var target = new CompanyProfileController(Mock.Of<ICompanyProfileService>(), companyService.Object)
            {
                WebImageFactory = factory.Object
            };
            // Act
            target.GetProfileImage(99);
            // Assert
            image.Verify(i => i.Write(null), Times.Once);
        }
