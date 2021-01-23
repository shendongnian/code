    [Test]
        public void Index_ReturnsCorrectModel()
        {
            // Arrange
             var post = new Post
             {
                  Slug = "continuing-to-an-outer-loop",
                  Title = "Continuing to an outer loop",
                  Summary = "When you have a nested loop, sometimes",
                  Content = "When you have a nested loop, sometimes",
                  PublishedAt = DateTime.Now.AddDays(7),
                  Tags = new Collection<Tag> { new Tag { Name = "Programming" } }
           };
           repository.Setup(repo => repo.All()).Returns(new[] { post });
            // Act
            var actual = controller.Index().Model;
            // Assert
            Assert.IsAssignableFrom<IEnumerable<PostViewModel>>(actual);
            repository.Verify(repo => repo.All(), Times.Once);
        }
