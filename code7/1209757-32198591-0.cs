    using (var ctx = new ClientContext(webUri))
    {
         var list = ctx.Web.Lists.GetByTitle(listTitle);
         var items = list.GetItems(CamlQuery.CreateAllFoldersQuery());
         ctx.Load(items, icol => icol.Include(i => i.RoleAssignments.Include( ra => ra.Member), i => i.DisplayName ));
         ctx.ExecuteQuery();
         foreach (var item in items)
         {
            Console.WriteLine("{0} folder permissions",item.DisplayName);
            foreach (var assignment in item.RoleAssignments)
            {
                Console.WriteLine(assignment.Member.Title);
            }
         }
    }
