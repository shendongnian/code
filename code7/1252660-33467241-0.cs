            [Authorize(Roles="Admin, GroupA, GroupB")]
            public class MyController : Controller
            {
                public async Task<ActionResult> AddOrder(Order order)
                {
                     var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        
                     //returns all roles for the user Id
        
                      var roles = await userManager.GetRolesAsync(User.Identity.GetUserId());
    
                      //Additionally you may want to check the role exist
                      var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
                      var roleManager = new RoleManager<IdentityRole>(roleStore);
    
                      bool isRoleExist = await roleManager.RoleExistsAsync("Admin");          
                      return View();
                }
            }
