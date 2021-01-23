    namespace mvc.Models
    {
        public static class StaticClass
        {
            public static bool IsAdmin
            {
                get { return (bool)HttpContext.Current.Session["IsAdmin "]; }
                set { HttpContext.Current.Session.Add("IsAdmin ", value); }
            }
        }
    }
