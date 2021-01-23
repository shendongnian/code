    internal class Derived1 : Base
    {
        private readonly Base baseCase;
        private Task<bool> task;
        public Derived1(Base baseCase)
        {
            this.baseCase = baseCase;
        }
        public override bool IsRunning
        {
            get { return false; }    
    
        }
    
        public override Task<bool> Run()
        { 
            bool ok = DoSomething(); 
            return Task.FromResult(ok);
        }
    }
