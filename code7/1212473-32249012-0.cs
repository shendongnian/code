    interface IMyInterface {
        void Register(string name);
    }
    class MyImplementation {
        public void RegisterName(string name) {
            // Wrong Register
        }
        public void RegisterName(string name) {
            // Right Register
        }
    }
