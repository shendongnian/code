    Expression<Func<MyEntities, Entity1, bool>> filterTemplate = (ctx, e1) =>
        ctx.Set2.Any(e2 => e2.Data.StartsWith(e1.Prefix));
    using(var context = new MyEntities())
    {
        Expression<Func<Entity1, bool>> filter = e1 =>
            filterTemplate.Invoke(context, e1); // .Invoke() -> LinqKit
        var result = context.Set1.Where(filter.Expand()).ToList(); // .Expand() -> LinqKit
        // or
        var result = context.Set1.AsExpandable().Where(filter).ToList(); // .AsExpandable() -> LinqKit
    }
