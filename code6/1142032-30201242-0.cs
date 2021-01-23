    public class EntityFrameworkConfiguration: DbConfiguration
    {
        public EntityFrameworkConfiguration()
        {
            this.SetModelCacheKey(ctx => new EntityModelCacheKey((ctx.GetType().FullName + ctx.Database.Connection.ConnectionString).GetHashCode()));
        }
    }
