        public class Foo {    
            // Constructor
            public Foo() {
                // Specify a specific implementation in the constructor instead of using dependency injection
                Service service1 = new ServiceExample();
            }
            private void RandomMethod() {
                Service service2 = new ServiceExample();
            }
        }
