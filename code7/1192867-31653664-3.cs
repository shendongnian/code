    <li>
        <a runat="server" href="~/Account/Manage" title="Manage your account"> Hello,
            <%: HttpContext.Current.GetOwinContext()
                .GetUserManager<YourNamespace.ApplicationUserManager>()
                .FindById(Context.User.Identity.GetUserId()).FirstName %>!
       </a>
    </li>
