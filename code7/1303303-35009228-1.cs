    class SimpleClass
    {
        // Static variable that must be initialized at run time.
        static readonly long baseline;
    
        static SimpleClass () {
            baseline = = DateTime.Now.Ticks;
        }   
    }
