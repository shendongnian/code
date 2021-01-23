    namespace WebMatrix.WebData
    {
        public static class WebSecurity
        {
            //...
            public static bool IsAuthenticated
            {
                get {  return Request.IsAuthenticated; }
            }
            //...
        }
    }
