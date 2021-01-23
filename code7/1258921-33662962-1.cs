    class Example
    {
        Class1 instance; // Valid
        public void someOtherFunction (Class1 class1) //Works  
        {  
            this.class1 = class1; //Does not warn about anything because this is type safe.
            class1.SomeFunction(); // Works
            var content = class1.Content // Compile Error: type class1 does not have such member "Content"
        }
    }
