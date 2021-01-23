    class TheFirstClass : TheBaseClass
    {   
        //public abstract void Process(ContextClass context)
        public override void Process(ContextClass context)
        {
            context.test = "success";
            base.Process(context); // calls TheBaseClass.Process method
        }
    }
