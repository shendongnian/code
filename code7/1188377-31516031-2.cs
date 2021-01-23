    public class Criteria
    {
        public string PropertyName { get; set; }
        public Operation OperationType { get; set; }
        public string OperationValue { get; set; }
        public enum Operation
        {
            EqualTo,
            GreaterThan,
            LessThan,
            Contains
        }
        public Criteria(string propertyName, Operation operationType, string operationValue)
        {
            this.PropertyName = propertyName;
            this.OperationType = operationType;
            this.OperationValue = operationValue;
        }
    } 
