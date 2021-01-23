            public static List<SomeServiceType> MyFunction(string url, string UserName, string Password)
            {
                List<SomeServiceType> list = new List<SomeServiceType>();
                if (url != null && UserName != null && Password != null)
                {
                    list = new SomeServiceType()
                    {
                        Url = "htp://www.test.com/",
                        Credentials = new NetworkCredential(UserName, Password)
                    };
                }
                return list;
            }
