    // Stores UserManager
    private readonly UserManager<ApplicationUser> _manager; 
    
    // Inject UserManager using dependency injection.
    // Works only if you choose "Individual user accounts" during project creation.
    public DemoController(UserManager<ApplicationUser> manager)  
    {  
        _manager = manager;  
    }
    
    // You can also just take part after return and use it in async methods.
    private async Task<ApplicationUser> GetCurrentUser()  
    {  
        return await _manager.GetUserAsync(HttpContext.User);  
    }  
    
    // Generic demo method.
    public async Task DemoMethod()  
    {  
        var user = await GetCurrentUser(); 
        string userEmail = user.Email; // Here you gets user email 
        string userId = user.Id;
    }  
