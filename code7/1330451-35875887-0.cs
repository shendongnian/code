    public class MyOwnEnum
    {
        public string Value { get; private set; }
        private MyOwnEnum(string value)
        {
            Value = value;
        }
        public static readonly MyOwnEnum FirstName = new MyOwnEnum("Firstname");
        public static readonly MyOwnEnum LastName = new MyOwnEnum("LastName");
    }
