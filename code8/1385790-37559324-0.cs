    public class MyRole : IdentityRole<string> 
    {
    }
    
    services.AddIdentity<MyUser, MyRole>()
            .AddEntityFrameworkStores<MyContext>()
            .AddDefaultTokenProviders()
            .AddOpenIddict();
