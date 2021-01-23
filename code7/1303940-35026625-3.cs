    public class RolesViewModel
    {
        public string UserName { get; set; }
        public bool UserRole { get; set; }
        public bool SuperUserRole { get; set; }
        public bool AdminRole { get; set; }
    }
    
    public ActionResult UserList()
    {
        var userRoles = new List<RolesViewModel>();
        var context = new ApplicationDbContext();
        var userStore = new UserStore<ApplicationUser>(context);
        var userManager = new UserManager<ApplicationUser>(userStore);
    
    
        foreach (var user in userStore.Users)
        {
            var r = new RolesViewModel()
            {
                UserName = user.UserName,
                UserRole = userManager.GetRoles(user.Id).Contains("User"),
                SuperUserRole = userManager.GetRoles(user.Id).Contains("SuperUser"),
                AdminRole = userManager.GetRoles(user.Id).Contains("Admin")
            };
            userRoles.Add(r);
        }
    
        return View(userRoles);
    }
        }
    }
    
    <table class="table table-hover">
    <tr>
        <th>
            User Name
        </th>
        <th>
            User
        </th>
        <th>
            Super User
        </th>
        <th>
            Admin
        </th>
    </tr>
    @foreach (var item in Model)
    {
        <tr>
            <td>
                @Html.DisplayFor(m => item.UserName)
            </td>
            <td>
                @Html.CheckBoxFor(m => item.UserRole)
            </td>
            <td>
                @Html.CheckBoxFor(m => item.SuperUserRole)
            </td>
            <td>
                @Html.CheckBoxFor(m => item.AdminRole)
            </td>
        </tr>
    }
    </table>
