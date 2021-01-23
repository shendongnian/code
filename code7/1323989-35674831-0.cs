    public class ExampleClass
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        protected ExampleClass() {
        }
        static ExampleClass _instance;
        public static ExampleClass Instance {
            get {
                return _instance ?? (_instance = new ExampleClass());
            }
        }
    }
