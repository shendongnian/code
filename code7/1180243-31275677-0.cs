    [Serializable]
    public class FilterDescriptor : ValueObject
    {
        public FilterOperator FilterOperator { get; set; }//this is an enum value
        // cannot map object
        // public object Value { get; set; }
        public string StringValue { get; set; }
        // and we can do some magic later
        public object Value { get { ... use the StringValue } ... }
    } 
