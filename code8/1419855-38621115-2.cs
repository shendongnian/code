    public class Foo
    {
        // this .ctor expects a type of Extension, not a string.
        public Foo(Extension ext) 
        { 
            // do something
        }
    }
    
    // This class has only constant string values.
    public class Extension
    {
        public const string TXT = ".txt";
        public const string XML = ".xml";
    }
