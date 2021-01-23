    public abstract class ModelBase
    {
        public bool DataRowDeleted { get; set; }
        public abstract T ModelFactoryFromLinq<T>() where T : class;
    }
    public class AreaModel
    {
    }
    public class Area : ModelBase
    {
        public override T ModelFactoryFromLinq<T>()
        {
            throw new NotImplementedException();
        }
    }
    public static List<TModel> LoadListOfAreaModels<TContext, TModel>(bool includeDeleted = false)
        where TContext : Area
        where TModel : class
    {
        using (var dc = new LinqToSqlDataContext())
        {
            IQueryable<TContext> filtered = includeDeleted
                ? dc.Set<TContext>().Where((c) => !c.DataRowDeleted)
                : dc.Set<TContext>();
            return filtered.Select((c) => c.ModelFactoryFromLinq<TModel>()).ToList();
        }
    }
