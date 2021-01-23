    interface IAdaper {
        SomeMethod();
    }
    
    class AdapterOne : IAdapter {
        TypeOneToCall  _one;
        public AdapterOne (TypeOneToCall one) {
            _one = one;
        }
        public SomeMethod() {
            return _one.SomeMethod();
        }
    }
    class AdapterTwo : IAdapter {
        TypeOneToCall  _two;
        public AdapterOne (TypeTwoToCall two) {
            _two = two;
        }
        public SomeMethod() {
            return _two.SomeMethod();
        }
    }
    class Generic<T> where T : IAdapter {
        // Your implementation here.
    }
