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
