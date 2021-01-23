    public class ValueHolder
    {
        public string Value { get; private set; }
        public void AssignValue()
        {
            this.Value = "the result";
        }
    }
    // usage
    var vh = new ValueHolder();
    RequiredMethod(vh.AssignValue);
    // access value
    vh.Value
