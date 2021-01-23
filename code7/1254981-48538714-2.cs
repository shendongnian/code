    public class MyRouteAttribute : Attribute
    {
        public string Url { get; private set; }
    
        public MyRouteAttribute (string url)
        {
            Url = url;
        }
    }
