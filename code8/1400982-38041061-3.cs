    // Initialize just two fields and leave the other to their defaults
    // (null for both strings and nullable ints)
    User u = new User();
    u.UserID = 1;
    u.Name = "Steve";
    bool ok = UpdateUser(u);
    if(ok) ......
    public UpdateUser(User info)
    {
        using(SqlConnection cnn = new SqlConnection(@"Data Source=(LOCAL);
                                                    Initial Catalog=TestDB;
                                                    Integrated Security=True;"))
        {
            cnn.Open();
    
            // Prepare the parameters to pass to Dapper Execute 
            var pms = new
            {
               UserID = info.UserID   
               FirstName = info.Name,
               FamilyName = info.FamilyName,  // <- this is null
               Age = info.Age,                // <- this is null
               Sex = info.Sex                 // <- this is null
            };
    
            int rows = cnn.Execute(@"UPDATE [UserTable] 
                                     SET FirstName= @FirstName,
                                         LastName = @LastName, 
                                         Age = @Age, 
                                         Sex = @Sex
                                     WHERE UserID = @UserID",
                                     pms);
             return rows != 0;
        }
    }
