    public class Demo : Demo.Impl {
        // Private interface
        private interface Impl {
            public bool IsValidState {get;}
            void DoIt();
        }
        // Implementation for the error state
        private class Error : Impl {
            public bool IsValidState { get { return false; } }
            public void DoIt() {
                Console.WriteLine("Invalid state.");
            }
        }
        private readonly string name;
        // Implementation for the non-error state
        public bool IsValidState { get { return true; } }
        public void DoIt() {
            Console.WriteLine("Hello, {0}", name);
        }
        // Constructor assigns impl depending on the parameter passed to it
        private readonly Impl impl;
        // Users are expected to use this method and property:
        public bool IsValid {
            get {
                return impl.IsValidState;
            }
        }
        public void SayHello() {
            impl.DoIt();
        }
        // Constructor decides which impl to use
        public Demo(string s) {
            if (s == null) {
                impl = new Error();
            } else {
                impl = this;
                name = s;
            }
        }
    }
