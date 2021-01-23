    public class DerivedClass: AbstractClass
    {
        public DerivedClass(Args args)
            : base(args)
        {
        }
    
        protected override void BuildResponses()
        {
            FormLoad(args);
        }
    }
