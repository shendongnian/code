    using System;
    class Example {
        int somePropertyValue;
        // this is a property: these are actually two methods, but from your 
        // code you must access this like it was a variable
        public int SomeProperty {
            get { return somePropertyValue; }
            set { somePropertyValue = value; }
        }
    }
    class Program {
        static void Main(string[] args) {
            Example e = new Example();
        
            // you access properties like this:
            e.SomeProperty = 3; // this calls the set method
            Console.WriteLine(e.SomeProperty); // this calls the get method
            // you cannot access properties by calling directly the 
            // generated get_ and set_ methods like you were doing:
            e.set_SomeProperty(3);
            Console.WriteLine(e.get_SomeProperty());
        }
    }
