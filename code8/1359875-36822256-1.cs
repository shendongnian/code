    // in your EF code you will have something like this ...
    Public async Task<User> SaveUser(User userModel)
    {
       try
      {
          var newUser = await context.Users.AddAsync(userModel);
          await context.SavechangesAsync();
          return newUser;
      }
      catch(Exception ex) {}
    }
    
    // and in your WebAPI controller something like this ...
    
    HttpPost]
    public async Task<HttpResponseMessage> Post(User newUser)
    {
         return Ok(await SaveUser(newUser);
    }
