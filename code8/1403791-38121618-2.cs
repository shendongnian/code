    public Task CreateAsync(ApplicationUser user)
    {
    
         if (user == null)
         {
             // this part of code will return from the method with an exception
             throw new ArgumentNullException("user");
         }
    
         // but this part of code is also expected to return something
         return Task.Run(() => { Console.WriteLine("Hello Task library!"); });
    
    }
