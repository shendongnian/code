            MyBaseClass inst = new MyDerivedClass();
            inst.B(); //Works fine 
            MyDerivedClass inst1 = new MyDerivedClass();
            inst1.B(); //Works fine
            IMyInterface inst2 = new MyDerivedClass();
            inst2.B(); //Compile time error
