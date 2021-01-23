    abstract class MyBaseClass {
        virtual void DoSomething() 
        {
            // do nothing
        }
    }
    class Derived : MyBaseClass {
        override void DoSomething() 
        { 
            Console.WriteLine(); 
        }
    }
