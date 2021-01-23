    interface IDoThis
    {
        void DoThis();
    }
    
    class Dependency : IDoThis
    {
        protected internal virtual void DoThis()
        {
            // impl.
        }
    
        void IDoThis.DoThis()
        {
            this.DoThis();
        }
    }
    IDoThis idt = new Dependency();
    idt.DoThis() // calls into the protected method.
