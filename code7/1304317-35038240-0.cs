    public class SingleValue<T>{
        public T Value {get;set;}
    }
    int n = context.Database.SqlQuery<SingleValue<int>>(
      "SELECT object_id as Value from sys.tables where sys.tables.name = 'Projects'")
      .ToList().Select(x=>x.Value).FirstOrDefault();
