    using System;
    using System.Collections.Specialized;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SampleWebApplication.Controllers;
    namespace SampleUnitTestProject
    {
        [TestClass]
        public class HomeTests
        {
            private Mock<HttpRequestBase> RequestMock;
            private Mock<HttpResponseBase> ResponseMock;
            private Mock<HttpContextBase> ContextMock;
    
            [TestInitialize]
            public virtual void Setup()
            {
                this.RequestMock = new Mock<HttpRequestBase>();
                this.ResponseMock = new Mock<HttpResponseBase>();
                this.RequestMock.Setup(m => m.QueryString).Returns(new NameValueCollection());
                this.RequestMock.Setup(m => m.Url).Returns(new Uri("http://www.somedomain.com"));
                this.ContextMock = new Mock<HttpContextBase>();
    
                this.ContextMock.Setup(m => m.Request).Returns(this.RequestMock.Object);
                this.ContextMock.Setup(m => m.Response).Returns(this.ResponseMock.Object);
            }
    
            [TestMethod]
            public void Test_Index()
            {
                // Arrange
    
                using (var controller = new HomeController())
                {
                    this.RequestMock.Setup(c => c.ApplicationPath).Returns("/tmp/testpath");
                    this.ResponseMock.Setup(c => c.ApplyAppPathModifier(It.IsAny<string>())).Returns("/mynewVirtualPath/");
                    var requestContext = new RequestContext(this.ContextMock.Object, new RouteData());
                    controller.Url = new UrlHelper(requestContext, new RouteCollection());
    
                    // Act
                    var result = controller.Index();
    
                    // Assert
                }
            }
        }
    }
