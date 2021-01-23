    you need some sort of structure to your code
    class foo
    {  
       public int I = 123; // is okay
        /*The following line boxes i.*/ 
       public object o = new object();
       foo()
       { // operations in a body
        o = 123;
        i = (int)o;  // unboxing
       }
    }
