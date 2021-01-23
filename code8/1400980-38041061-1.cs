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
    
            // Prepare the parameters to pass to the Dapper Execute 
            var pms = new
            {
               UserID = info.UserID   
               FirstName = info.Name,
               LastName = info.FamilyName,  // <- from here all is null
               Age = info.Age,
               Sex = info.Sex
            };
    
            int rows = cnn.Execute(@"UPDATE [UserTable] 
                                     SET FirstName= @FirstName,
                                     LastName = @LastName, 
                                     Active = @Active, 
                                     Age = @Age, 
                                     Sex = @Sex
                                     WHERE UserID = @UserID",
                                     pms);
             return rows != 0;
        }
    }
