        public List<Users> GetUsers()
            {
                List<Users> users=new  List<Users> ();
                DataSet ds=getDataSet(string sqlStatement)
                Users user;
    
                 foreach(DataRow row in DataSet.Table[0].Rows)
                 {
                   user=new Users();
                   user.FirstName=row["firstname"]
                    ....
                    ....
                   list.Add(user)
    
                 }
        
                // Database connection to go here along with the list population
                // Something like this?
                //
                // new User
                //     ID = 
                //     FirstName = 
                //     LastName =   
        
                //  Users = CollectionViewSource.GetDefaultView(_users);
        
        
        
                return users;
            }
