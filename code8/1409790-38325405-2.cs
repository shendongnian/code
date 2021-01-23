        [Test]
        public void TestGetName()
        {
            // Arrange
            var sut = new HomeController();
            Thread.CurrentPrincipal = new TestPrincipal(new Claim("name", "John Doe"));
            // Act
            var viewresult = sut.GetName() as ContentResult;
            // Assert
            Assert.That(viewresult.Content, Is.EqualTo("John Doe"));
        }
