    public abstract class SomeClass
    {
        public SomeClass(string a, string b)
        {
           // ...
        }
        public SomeClass()
        {
          //...
        }
    }
    public SomeDerivedType : SomeClass
    {
         public SomeDerivedType(string a, string b) : base(a, b)
         {
             // ...
         }
         public SomeDerivedType() : base("test", "string")
         {
            // ..
         }
    }
