    class Baseclass
    { 
        public void fun()
        { 
            Console.Write("Base class" + " ");
        } 
    } 
    class Derived1 : Baseclass
    { 
        new public void fun()
        {
            Console.Write("Derived1 class" + " "); 
        } 
    }
