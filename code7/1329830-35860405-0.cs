     public static class Connections
        {
            private static Dictionary<string, SqlConnection> _Connection = new Dictionary<string, SqlConnection>();
            public static Dictionary<string, SqlConnection> Connection
            {
                get { return _Connection; }
                set { _Connection = value; }
            }
            public static void Init(string Name)
            {
                string user=HttpContext.Current.Session["UserId"].ToString();
                if (!Connection.ContainsKey(user))
                {
                    Connection.Add(user, new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Name].ConnectionString));
                }
                else
                {
                    if (Connection[user] == null)
                    {
                        Connection[user] = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings[Name].ConnectionString);
                    }
                }
            }
        }
