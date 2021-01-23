    class foo
    {  
        public int I = 123; // is okay
        /*The following line boxes i.*/ 
        public object O = new object();
        foo()
        {
            // operations in a body
            O = 123;
            I = (int)O;  // unboxing
        }
    }
