    public class BaseClass : AbstractBaseClass, ISerializable
    {
        public int Foo { get; set; }
    
        protected BaseClass(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // ...
            Foo = info.GetInt32("Foo");
            // ...
      }
    }
