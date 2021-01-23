    @using Microsoft.AspNet.Identity
    @using YourModelnameHere.Models
    @if (Request.IsAuthenticated)
    {
    using (Html.BeginForm("LogOff", "Account", FormMethod.Post, new { id = "logoutForm", @class = "navbar-right" }))
    {
    @Html.AntiForgeryToken()
    <ul class="nav navbar-nav navbar-right">
        <li>
           @{
             var currentUserId = User.Identity.GetUserId();
             var manager = new UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new ApplicationDbContext()));
             var currentUser = manager.FindById(User.Identity.GetUserId()); 
           }
           @Html.ActionLink("Hello " + currentUser.FirstName + "!", "Manage", "Account", routeValues: null, htmlAttributes: new { title = "Manage" })
    
           @Html.ActionLink("Hello " + User.Identity.GetUserName() + "!", "Manage", "Account", routeValues: null, htmlAttributes: new { title = "Manage" }) // I no longer need this ActionLink!!!
        </li>
