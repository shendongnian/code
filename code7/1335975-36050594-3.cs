    class Test
    {
        // global variable.
        int va = 1;
        int vb = 2;
    
        public void local()
        {
            bool va = false;   // local variable
            Console.WriteLine(va);  // va is bool here.use local value.
            Console.WriteLine(vb); // vb is int, use global value.
        }
    }
