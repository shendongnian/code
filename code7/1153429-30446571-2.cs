    abstract class TheBaseClass
    {
        public abstract void Process(ContextClass context);
        public void CallTheProcess(ContextClass context)
        {
            // other necessary stuff
            context.test = "Base Class";
        }
    }
    class TheFirstClass : TheBaseClass
    {   
        public override void Process(ContextClass context)
        {
            context.test = "success";
            // some operations
        }
    }
    class TheLastClass : TheFirstClass
    {
        public override void Process(ContextClass context)
        {
            base.CallTheProcess(context); // from the TheBaseClass
            base.Process(context); // from the TheFirstClass
            // other operations
        }
    }
