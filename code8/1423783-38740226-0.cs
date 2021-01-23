    var result = context.AspNetRoles
        .Where(o => context.RoleActions.Any(oo => oo.RoleId == o.Id) &&
            o.UserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
        .Select(o => o.Name)
        .ToList();
