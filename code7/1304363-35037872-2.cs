    class base1
    {
        public int x = 1;
        public int y = 1;
    }
    
    class inherit1:base1
    {
        int z = 5;
      ...
    }
    base bs=new base1();
    // bs now has x = y = 1    
    inherit1 i1=new inherit1(); 
    // inherit1 also has x = y = 1, and z = 5
