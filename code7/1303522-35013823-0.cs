    using(var ctx = new MyContext())
    {
       ctx.Configuration.LazyLoadingEnabled = false;
       var events = ctx.AllEvent.ToList();
       foreach(var event in events)
       {
          event.Users = ctx.Users.Where(u => 
                         event.AttendingUsers.Split(',').ToList().Contains(u.id)).ToList();
       }
    }
