    public class Repository<T>
    {
        protected DbContext1 DbCtxt1 { get; }
        protected DbContext2 DbCtxt2 { get; }
    
        public Repository<T>(DbContext1 ctx1, DbContext2 ctx2)
        {
          DbCtxt1 = ctx1;
          DbCtxt2 = ctx2;
        }
    }
