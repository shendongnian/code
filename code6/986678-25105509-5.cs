    [Test]
        public void Index_ReturnsCorrectModel()
        {
            // Arrange
            repository.Setup(repo => repo.All()).Returns(Enumerable.Empty<Post>());
            // Act
            var actual = controller.Index().Model;
            // Assert
            Assert.IsAssignableFrom<IEnumerable<PostViewModel>>(actual);
            repository.Verify(repo => repo.All(), Times.Once);
        }
