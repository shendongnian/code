    using System.Linq;
    ...
    using(var ctx = new CmsContext())
    {
        var allEntitiesInSet = ctx.Set(_tableName).ToList();
    }
