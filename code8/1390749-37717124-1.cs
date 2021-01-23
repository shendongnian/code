    [NotMapped]
    [Computed]
    public string FullName
    {
         get { return FirstName + " " + LastName; }
    }
    var q = dbContext.Users.Select(u => new
         {
             FullName = u.FullName
         }).Decompile(); 
