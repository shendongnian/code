    class Base {
        protected bool MyProperty {get;set;}
    }
    class Derived : Base {
        public bool IsWhatIWant() {
             return MyProperty;
        }
    }
    main.cs {
        var derivedList = //a List<Derived>()
        var whatIWanted = derivedList.Where(d => d.IsWhatIWant());
    }
