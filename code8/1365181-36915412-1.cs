    public abstract class ModelBase<T> where T : class
    {
        public bool DataRowDeleted { get; set; }
        public abstract T ModelFactoryFromLinq();
    }
    public class AreaModel
    {
    }
    public class Area : ModelBase<AreaModel>
    {
        public override AreaModel ModelFactoryFromLinq()
        {
            throw new NotImplementedException();
        }
    }
    public static List<TModel> LoadListOfAreaModels<TContext, TModel>(bool includeDeleted = false)
        where TContext : ModelBase<TModel>, new()
        where TModel : class
    {
        using (var dc = new LinqToSqlDataContext())
        {
            IQueryable<TContext> filtered = includeDeleted
                ? dc.Set<TContext>().Where((c) => !c.DataRowDeleted)
                : dc.Set<TContext>();
            return filtered.Select((c) => c.ModelFactoryFromLinq()).ToList();
        }
    }
