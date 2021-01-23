    using (var ctx = new ClientContext(webUri))
    {            
        ctx.Load(ctx.Web.Webs, wcol => wcol.Include(w => w.HasUniqueRoleAssignments, w => w.Title, w => w.RoleAssignments));
        ctx.ExecuteQuery();
        foreach (var web in ctx.Web.Webs)
        {
            Console.WriteLine(web.HasUniqueRoleAssignments);
        }
    } 
