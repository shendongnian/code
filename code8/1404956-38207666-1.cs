    public class MySession
    {
        // private constructor
        private MySession()
        {
            Filters = new List<PageValueItem>();
        }
        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }
        public static void SaveFilterValue(string ID, string value)
        {
            MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
            if (session == null)
            {
                session = new MySession();
                session.Filters.Add(new PageValueItem(ID, value));
                HttpContext.Current.Session["__MySession__"] = session;
            }
            else
            {
                session.Filters.Add(new PageValueItem(ID, value));
                HttpContext.Current.Session["__MySession__"] = session;
            }
        }
        public static string GetFilterValue(string ID)
        {
            string retVal = null;
            MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
            if (session != null)
            {
                foreach(PageValueItem pvi in session.Filters)
                {
                    if(pvi.ID == ID)
                    {
                        retVal = pvi.Value;
                    }
                }
                
            }
            return retVal;
           
        }
        private List<PageValueItem> Filters;
    }
