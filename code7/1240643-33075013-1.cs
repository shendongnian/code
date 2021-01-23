    public MyDerivedClass : MyBaseClass
    {
        public override void MyPublicMethod()
        {
            MyPrivateMethod(false);
        }
    }
    
    public MyBaseClass   
    {
        public virtual void MyPublicMethod()
        {
            MyInternalMethod(true);
        }
    
        protected void MyInternalMethod(bool isInternal)
        {
            // If you're planning to use isInternal to change the logic based
            // on whether this code has been invoked in the base or subclass
            // you would be infinitely better off overriding that code in the
            // subclass. Or better still don't use generalization at all and
            // use an injection framework and create several implementations
            // of an interface.
        }
    }
