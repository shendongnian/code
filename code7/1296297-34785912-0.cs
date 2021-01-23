    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Principal;
    using System.Web.Http.Controllers;
    using Moq;
    
     public class CustomAuthorizeAttributeTest
    {
            private readonly Mock<HttpActionDescriptor> _actionDescriptorMock = new Mock<HttpActionDescriptor>() { CallBase = true };
            private readonly Collection<AllowAnonymousAttribute> _allowAnonymousAttributeCollection = new Collection<AllowAnonymousAttribute>(new AllowAnonymousAttribute[] { new AllowAnonymousAttribute() });
            private readonly MockableAuthorizeAttribute _attribute;
            private readonly Mock<MockableAuthorizeAttribute> _attributeMock = new Mock<MockableAuthorizeAttribute>() { CallBase = true };
            private readonly Mock<HttpControllerDescriptor> _controllerDescriptorMock = new Mock<HttpControllerDescriptor>() { CallBase = true };
            private readonly HttpControllerContext _controllerContext;
            private readonly HttpActionContext _actionContext;
            private readonly Mock<IPrincipal> _principalMock = new Mock<IPrincipal>();
            private readonly HttpRequestMessage _request = new HttpRequestMessage();
    
            public AuthorizeAttributeTest()
            {
                _attribute = _attributeMock.Object;
                _controllerContext = new Mock<HttpControllerContext>() { CallBase = true }.Object;
                _controllerDescriptorMock.Setup(cd => cd.GetCustomAttributes<AllowAnonymousAttribute>()).Returns(new Collection<AllowAnonymousAttribute>(Enumerable.Empty<AllowAnonymousAttribute>().ToList()));
                _actionDescriptorMock.Setup(ad => ad.GetCustomAttributes<AllowAnonymousAttribute>()).Returns(new Collection<AllowAnonymousAttribute>(Enumerable.Empty<AllowAnonymousAttribute>().ToList()));
                _controllerContext.ControllerDescriptor = _controllerDescriptorMock.Object;
                _controllerContext.Request = _request;
                _actionContext = ContextUtil.CreateActionContext(_controllerContext, _actionDescriptorMock.Object);
                _controllerContext.RequestContext.Principal = _principalMock.Object;
            }
    		
    		[Fact]
            public void OnAuthorization_IfUserIsNotInUsersCollection()
            {
                _attribute.Users = "John";
                _principalMock.Setup(p => p.Identity.IsAuthenticated).Returns(true).Verifiable();
                _principalMock.Setup(p => p.Identity.Name).Returns("Mary").Verifiable();
    
                _attribute.OnAuthorization(_actionContext);
    
                AssertUnauthorizedRequestSet(_actionContext);
                _principalMock.Verify();
            }
    		
    		private static void AssertUnauthorizedRequestSet(HttpActionContext actionContext)
            {
                Assert.NotNull(actionContext.Response);
                Assert.Equal(HttpStatusCode.Unauthorized, actionContext.Response.StatusCode);
                Assert.Same(actionContext.ControllerContext.Request, actionContext.Response.RequestMessage);
            }
    }
