    class Program
    {
        static void Main(string[] args)
        {
            var test = new TableMapper<A>();
            var fr = test.GetForeignRelation();
            var type = fr.ModelType;
            var newInstance = Activator.CreateInstance(type);
        }
    }
    
    public class TableMapper<TSource>
    {
    
        public TableMapper()
        {
        }
    
        public ReportRelation GetForeignRelation()
        {
            return new ReportRelation
            {
                ModelType = typeof(TSource)
            };
        }
    }
    
    public class ReportRelation
    {
        public Type ModelType { get; set; }
    }
    
    public class A
    {
        public string Test { get; set; }
        public A()
        {
            Test = "Some string";
        }
    }
