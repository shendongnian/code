    static class Example {
        static void Sample(ISpeaker input) {
            input.Speak(); // this call acts like a control structure
        }
    }
    
    interface ISpeaker {
        void Speak();
    }
    
    class Cat : ISpeaker {
        public void Speak() {
            Console.WriteLine("Meow");
        }
    }
    
    class Dog : ISpeaker {
        public void Speak() {
            Console.WriteLine("Woof");
        }
    }
