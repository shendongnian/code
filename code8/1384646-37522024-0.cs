    public List<User> Userlist()
            {
                ObjectCache cache = MemoryCache.Default;
    
                var users = cache["users"];
    
                if (users == null)
                {
                    CacheItemPolicy policy = new CacheItemPolicy();
    
                    //For dmonstration, I used cache expring after 1 day
                    //Set the cache policy as per your need
                    policy.AbsoluteExpiration = DateTime.Now.AddDays(1);
    
    
                    // Fetch the users here from database
                    List<User> userList = GetUsersFromDatabase();
    
                    //Set the users in the cache
                    cache.Set("users", userList, policy);
                    
                }
    
                return cache["users"] as List<User>;
            }
    
            private static List<User> GetUsersFromDatabase()
            {
                string strSQL = "";
                List<User> users = new List<User>();
                strSQL = "select USERID,USERNAME,PASSWORD from USERS";
    
                //if (Userlist().Count > 0)
                //{
                //    return Userlist();
                //}
                //else
                //{
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (var command = new SqlCommand(strSQL, connection))
                    {
                        connection.Open();
                        using (var dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                users.Add(new User { Id = Convert.ToInt32(dataReader["USERID"]), user = dataReader["USERNAME"].ToString(), password = Decrypt(dataReader["PASSWORD"].ToString()), estatus = true, RememberMe = true });
                            }
                        }
                    }
                }
                return users;
            }
