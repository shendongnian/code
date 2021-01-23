    public class Foo
    {
        string someField = "foo";
        string someOtherField;   // can't initialize yet
        public Foo()
        {
            someOtherField = someField + "bar";
        }
    }
