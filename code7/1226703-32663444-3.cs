    namespace WebMatrix.WebData
    {
        //other class content omitted for brevity
        public static class WebSecurity
        {
            public static bool IsAuthenticated
            {
                get {  return Request.IsAuthenticated; }
            }
        }
    }
