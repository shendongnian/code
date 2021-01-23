    public class OurBaseClass
    {
        public string StatusMessage { get; set;}
        // other properties
        protected void BaseInit()
        {
            // Set common properties here...
        }
        public virtual void Init()
        {
            BaseInit();
        }
    }
    public class ProcessClass : OurBaseClass
    {
        public string SomeProcessInformation { get; set;}
        public string SomeMoreProcessInformation { get; set;}
        
        public override void Init()
        {
            BaseInit();
            // Set specific properties here...
        }
    }
