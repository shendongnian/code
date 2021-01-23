    // You need a new type with a lot of boilerplate for every
    // Rust-like enum but they can all be implemented as a struct
    // containing an enum discriminator and an object value.
    // The struct is small and can be passed by value
    public struct RustyEnum
    {
        // discriminator type must be public so we can do a switch because there is no equivalent to Rust deconstructor
        public enum DiscriminatorType
        {
            // The 0 value doesn't have to be None 
            // but it must be something that has a reasonable default value 
            // because this  is a struct. 
            // If it has a struct type value then the access method 
            // must check for Value == null
            None=0,
            IVal,
            SVal,
            CVal,
        }
        // a discriminator for users to switch on
        public DiscriminatorType Discriminator {get;private set;}
        // Value is reference or box so no generics needed
        private object Value;
        // ctor is private so you can't create an invalid instance
        private RustyEnum(DiscriminatorType type, object value)
        {
            Discriminator = type;
            Value = value;
        }
        // union access methods one for each enum member with a value
        public int GetIVal() { return (int)Value; }
        public string GetSVal() { return (string)Value; }
        public C GetCVal() { return (C)Value; }
        // traditional enum members become static readonly instances
        public static readonly RustyEnum None = new RustyEnum(DiscriminatorType.None,null);
        // Rusty enum members that have values become static factory methods
        public static RustyEnum FromIVal(int i) 
        { 
            return  new RustyEnum(DiscriminatorType.IVal,i);
        }
        //....etc
    }
