    public abstract class BaseClass<TModel> where TModel : class
    {
        public bool DataRowDeleted { get; set; }
        public abstract TModel ModelFactoryFromLinq();
    }
    public class Area : BaseClass<AreaModel>
    {
        public override AreaModel ModelFactoryFromLinq()
        {
            return new AreaModel();
        }
    }
    public static List<TModel> LoadListOfAreaModels<TContext, TModel>(bool includeDeleted = false)
        where TContext : BaseClass<TModel>, new()
        where TModel : class
    {
        using (var dc = new LinqToSqlDataContext())
        {
            IQueryable<TContext> filtered = includeDeleted
                ? dc.GetTable<TContext>().Where((c) => !c.DataRowDeleted)
                : dc.GetTable<TContext>();
            return filtered.Select((c) => c.ModelFactoryFromLinq()).ToList();
        }
    }
