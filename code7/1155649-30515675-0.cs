    class Base {
        public bool MyProperty {get;set;}
    }
    class Derived : Base {
    
    }
    main.cs {
        var derivedList = //a List<Derived>()
        var whatIWanted = derivedList.Where(d => d.MyProperty);
    }
