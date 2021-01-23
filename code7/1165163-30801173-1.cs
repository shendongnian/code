    class MyClass {
        public void SpecialMethod() {
            var myName = WhatIsMyName();
        }
    
        private static string WhatIsMyName([CallerMemberName] string name= "") {
            return name;
        }
    }
