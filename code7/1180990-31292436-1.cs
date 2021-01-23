       Context.Entry(userCategory)
                  .Collection(uc => uc.Users)
                  .Query()
                  .Where(u => u.Username == username)//I'd put an index on username too
                  .Load();
       if(userCategory.Users.Any())
       {
          //Other operations
       }
