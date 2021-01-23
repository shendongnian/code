    class Base<T> {
        public class Inner {}
    }
    
    class Derived : Base<Derived.Inner2> {
        public class Inner2 : Inner {}
    }
