     public class HandleExceptionAttribute : System.Web.Mvc.HandleErrorAttribute
        {
            // Pass in necessary data, etc
            private string _data;
            public string Data
            {
                get { return _data; }
                set { _data = value; }
            }
    
            public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
            {            
                // Logging code here
                // Do something with the passed-in properties (Data in this code)
                // Use the filterContext to retrieve all sorts of info about the request
                // Direct the user
                base.OnException(filterContext);
            }
        }
