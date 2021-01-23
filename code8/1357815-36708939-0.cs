      @if (Request.IsAuthenticated)
                {
                     string[] r = Roles.GetRolesForUser();
                     string s = string.Join(",", r.ToList());
                    <h1>@s</h1>
    }
