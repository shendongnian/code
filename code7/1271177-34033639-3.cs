    public class SomeQueryClassName
    {
        public int QueryId { get; set; }
        public string ConnectionString { get; set; }
        public string CommandText { get; set; }
        public List<SomeParameterClassName> Parameters { get; set; }
    
        public SomeQueryClassName()
        {
            ....
        }
    }
    public class SomeParameterClassName
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DataType { get; set; }
        public object Value { get; set; }
    
        public SomeParameterClassName()
        {
            ....
        }
    }
