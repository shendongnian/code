    public class MyMessage : MessageBase
    {
        public MyMessage(IEnumerable<string> value)
        {
            Value = value;
        }
        public IEnumerable<string> Value { get; private set; } 
    }
