     public class MyContext
        {
            public MyContext(string username)
            {
                Username = username;
            }
    
            public string Username { get; private set; }
			
			public static MyContext CreateFromHttpContext(HttpContext httpContext){
				return new MyContext(HttpContext.Current.User.Identity.Name);
			}
        }
     public class MyRep
        {
			private readonly VtContext _context;
            
			public MyRep(MyContext context)
            {
                _context = context;
            }
    
			... other repository code...
	
        }
