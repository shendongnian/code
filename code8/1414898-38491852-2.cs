    class MyClass {
        // Instead of using the method name, use the "this" keyword.
        // Instead of parenthesis use square brackets
        
        // OLD: public string GetValue(string name) {
        
        public string this[string name] {
            switch(key)
            {
                case "Name":
                    return "John";
                case "Age":
                    return 30;
            }
        }
    }
