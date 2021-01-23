    `public class MockHttpContext : HttpContextBase
    {
        public MockHttpContext()
        {
            MockRequest = new Mock<HttpRequestBase>();
            // .. etc ..
            var actionExecutingContext = new Mock<ActionExecutingContext>();
            actionExecutingContext.SetupGet(x => x.HttpContext).Returns(this);
            var filter = new ThemeModelAttribute();
            filter.OnActionExecuting(actionExecutingContext.Object);
            // OnActionExecuted has similar setup if needed.
        }
    }`
