    public Task CreateAsync(ApplicationUser user)
    {
      if (user == null)
      {
         throw new ArgumentNullException("user");
      }
       Task.Factory.StartNew(() => { Console.WriteLine("Hello Task library!"); }); 
       // other operations
       return Task.CompletedTask;
     }
