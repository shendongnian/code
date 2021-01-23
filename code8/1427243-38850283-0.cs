        public void Update(UserEntity person)
            {
                UserEntity user = new UserEntity();
        
                SurveyEntities dbcontext = new SurveyEntities();
        
              //  var query = (from p in dbcontext.Users
              //               where p.UserId == person.UserId
             //                select new UserEntity() { UserId =p.UserId , FirstName = p.FirstName, LastName = p.LastName, Birth = p.Birth.Value, Password = p.Password, UserName = p.Username, Email = p.Email, Active = p.Active.Value }).SingleOrDefault();
        
      UserEntity tmp=  dbcontext.UserEntity.where(x=>x.userId==person.UserId).FirstDefault();
                    tmp.FirstName = person.FirstName;
                    tmp.LastName = person.LastName;
                    tmp.UserName = person.UserName;
                    tmp.Password = person.Password;
                    tmp.Email = person.Email;
                    tmp.Birth = person.Birth;
                    tmp.Active = person.Active;
        
        
                try
                {
                    dbcontext.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }
        
        
            }
