    void Main()
    {
        var context = new ContextClass();
        var LastClass = new TheLastClass();
        LastClass.CallTheProcess(context);
    }
    abstract class TheBaseClass
    {
        public abstract void Process(ContextClass context);
        public void CallTheProcess(ContextClass context)
        {
            this.Process(context); 
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
            base.Process(context); // from the TheFirstClass
            // other operations
        }
    }
