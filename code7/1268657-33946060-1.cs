    public List<Users> GetUsers()
                {
                    List<Users> users=new  List<Users> ();
                    DataSet ds=getDataSet("Select FirstName,...... from Users")
                    Users user;
        
                     foreach(DataRow row in ds.Tables[0].Rows)
                     {
                       user=new Users();
                       user.FirstName=row["firstname"]
                        ....
                        ....
                       list.Add(user)
        
                     }
    
                    return users;
                }
