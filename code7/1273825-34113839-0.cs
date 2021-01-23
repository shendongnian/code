            public static Settings Current
            {
                get
                {                    
                    if (HttpContext.Current.Session["Settings"] == null)
                    {
                        Settings s = new Settings();
                        HttpContext.Current.Session["Settings"] = s;
                        return s;
                    }
                    return (Settings)HttpContext.Current.Session["Settings"];
                }
            }
