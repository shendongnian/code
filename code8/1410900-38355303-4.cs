    public class MyControllerTests
    {
        public void MyTest()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo
                .Setup(s => s.GetUserInformation(It.IsAny<string>())
                .Returns(new MyObject()
                {
                    UserId = "whatever", // or whatever the mocked data needs to be
                    DateCreated = DateTime.MinValue
                });
        }
    }
