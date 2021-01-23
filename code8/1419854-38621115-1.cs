    public class Foo
    {
        // this .ctor expects a type of Extension, not a string.
        public Foo(Extension ext) 
        { 
            // do something
        }
    }
    
    public class Extension
    {
        public enum File
        {
            TXT,
            XML
        }
    }
