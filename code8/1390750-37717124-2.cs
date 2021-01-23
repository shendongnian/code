    public static Expression<Func<MyEntity, MyDto>> SelectFullNames()
    {
          return e => new MyDto{} { Fullname = e.FirstName + " " + e.LastName; 
    }
    
    var queryable = dbConext.Users.Select(SelectFullNames());
