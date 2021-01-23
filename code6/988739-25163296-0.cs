    public class MyAspxPage : Page
    {
        private Object _myObj = new object();
    
        public object GetObject()
        {
            return _myObj;
        }
    
        public static object GetAnObject()
        {
            return new object();
        }
    }
    
    public class MyWebService : WebService
    {
        public void MyWebServiceMethod1()
        {
            MyAspxPage page = new MyAspxPage();
            object result = page.GetObject();
        }
    
        public void MyWebServiceMethod2()
        {
            object result = MyAspxPage.GetAnObject();
        }
    }
