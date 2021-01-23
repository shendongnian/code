    AuthenticationController controller = new AuthenticationController();
    var httpContext = new MockHttpContext();
    //set cookie
    controller.ControllerContext = new ControllerContext(httpContext, controller);
    public class MockHttpContext : HttpContextBase
    {
        readonly HttpRequestBase _request;
        public MockHttpContext()
        {
            _request = new MockHttpRequest();
        }
        public override HttpRequestBase Request
        {
            get { return _request; }
        }
        class MockHttpRequest : HttpRequestBase
        {
            readonly HttpCookieCollection _cookies;
            public MockHttpRequest()
            {
                _cookies = new HttpCookieCollection();
            }
            public override HttpCookieCollection Cookies
            {
                get
                {
                    return _cookies;
                }
            }
        }
    }
