    class MyClass {
        private int someVariable;
        
        public int SomeVariable {
            get {return someVariable;}
            set {someVariable = value;}
        }
        
        public MyClass() {
            someVariable = 10;
            MyDelegate[] conditions = {
                (() => 7 < 10),
                (() => 77 == 77),
                (() => "Sweeper is awesome".Contains("Sweeper")),
                (() => String.IsNullOrEmpty(""))
            };
            SetValueForPropertyIf(conditions, ref someVariable, 20);
        }
    }
