    class M 
    {
        public int i;
        public PtrWrapper w;
        
        public M()
        {
            i = 42;
            w = new PtrWrapper(ref i);
        }
    }
        
    var m = new M();
    var value = m.w.Value; // probably 42
    
    // move m to gen 2
    GC.Collect();
    GC.Collect();
    
    value = m.w.Value; // probably a random value
