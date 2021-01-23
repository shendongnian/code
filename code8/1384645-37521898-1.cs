    private Lazy<IEnumerable<User>> users = new Lazy<IEnumerable<User>>(Userlist);
    public Lazy<IEnumerable<User>> Users
    {
      get
      {
        return this.users;
      }
    }
    
    public static IEnumerable<User> Userlist()
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
        // }
    }
