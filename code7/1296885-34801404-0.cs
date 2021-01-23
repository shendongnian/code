     public class BlogControllerFacts
     {
            public class Index
            {
                [Fact]
                public void GetDoesSomething()
                {
                    // Arrange
    				BlogContext db = new BlogContext(); // This should be mocked somehow
    				const int id = 5;
                    var controller = new BlogController(db);
     
                    // Act
                    var result = controller.Get(id);
     
                    // Assert something
                }
     
            }
        }
    }
