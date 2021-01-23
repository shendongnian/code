    using System.Web;
    
    using Moq;
    
    using NUnit.Framework;
    
    public class FooBase
    {
        public virtual ResultObject getX(HttpRequestBase request)
        {
            return new ResultObject { Id = 2 };
        }
    }
    
    public class Foo : FooBase
    {
        public override ResultObject getX(HttpRequestBase request)
        {
            return new ResultObject { Id = 4 };
        }
    }
    
    public class ResultObject
    {
        public int Id { get; set; }
    }
    
    [TestFixture]
    public  class Test
    {
        Mock<Foo> mockProvider = new Mock<Foo>();
    
        [Test]
        public void FooTest()
        {
            // Arrange
            var fakedResultObject = new ResultObject { Id = 8 };
            mockProvider.Setup(x => x.getX(It.IsAny<HttpRequestWrapper>())).Returns(fakedResultObject);
    
            // Act
            var result = mockProvider.Object.getX(new HttpRequestWrapper(new HttpRequest("filename", "http://foo.org", "querystring")));
    
            //Assert
            Assert.AreEqual(8, result.Id);
        }
    }
