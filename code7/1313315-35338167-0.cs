    @using (Html.BeginForm("GetUserRoles", "Manage"))
    {
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(true)
        <p>
            Users: @Html.DropDownList("UserName", (IEnumerable<SelectListItem>)ViewBag.Users, "Select ...")
            <input type="submit" value="Get roles" name="action:GetUserRoles" />
        </p>
    }
    @if (ViewBag.RolesForThisUser != null)
    {
        <hr/>
        <p>
            <text>User roles:</text>
            <ol>
                @foreach (var role in ViewBag.RolesForThisUser)
                {
                    using (Html.BeginForm("GetUserRoles", "Manage"))
                    {
                        @Html.AntiForgeryToken()
                        <li>@role 
                        <input type="hidden" name="UserName" value="@ViewBag.User" />
                        <input type="hidden" name="DeleteRoleName" value="@role" />
                        <input type="submit" value="Delete" name="action:DeleteRole" /></li>
                    }
                }
            </ol>
        </p>
    }
    @using (Html.BeginForm("GetUserRoles", "Manage"))
    {
        @Html.AntiForgeryToken()
        if (ViewBag.RolesForThisUser != null)
        {
            <p>
                <text> Role name: </text>
                @Html.DropDownList("RoleName", (IEnumerable<SelectListItem>)ViewBag.Roles, "Select ...")
                <input type="hidden" name="UserName" value="@ViewBag.User" />
                <input type="submit" value="Add role" name="action:AddRole"/>
            </p>
        }
    }
