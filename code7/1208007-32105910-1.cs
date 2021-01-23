    [AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    public class OperationAttribute : Attribute 
    {
        public OperationAttribute(string name, QueryOperation op)
        {
            ...etc...
        }
    }
    public class SceneQueryData
    {
        [PropertyFilter("Episode")]
        [Operation("le", QueryOperation.LessThanOrEquals)]
        [Operation("lt", QueryOperation.LessThan)]
        [Operation("ge", QueryOperation.GreaterThanOrEquals)]
        [Operation("gt", QueryOperation.GreaterThan)]
        public int? Episode { get; set; }
    }
