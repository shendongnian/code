    // Library written by BarCorp
    public abstract class Bar
    {
        // Derived class is responsible for initializing x.
        protected int x;
        protected abstract void InitializeX(); 
        public void M() 
        { 
           InitializeX();
           Console.WriteLine(x); 
        }
    }
 
