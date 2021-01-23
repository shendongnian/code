    public class Processor : IFluentProcessor1, IFluentProcessor2, IFluentProcessor3
    {
        private string _connectionName = String.Empty;
        private string _whereClause = String.Empty;
        private Processor() {}
        public static IFluentProcessor1 Create() { return new Processor(); }
        // ...
    }
