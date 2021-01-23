    abstract class MyBaseClass {
        virtual void DoSomething() { }
    }
    class Derived : MyBaseClass {
        override void DoSomething() { Console.WriteLine(); }
    }
