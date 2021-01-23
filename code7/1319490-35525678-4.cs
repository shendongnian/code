    public class MyClass
    {
        private HttpContext _httpContext;
        
        // **** The caller would supply HttpContext.Current here ****
        public MyClass(HttpContext httpContext) {               
            _httpContext = httpContext;
        }
        
        public void SomeMethod() {
            ...
            //  Do something here with _httpContext
            ...
        }
    }
