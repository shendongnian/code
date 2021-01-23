    public class OriginalClass
    {
        public virtual ResultClass MyMethod(string argOne, int argTwo)
        {/*...*/}
    }
    
    public class DerivedClass: OriginalClass
    {
        public override ResultClass MyMethod(string argOne, int argTwo)
        {/*New implementation of the original code...*/}
    }
    //[...]
    public void TestTheseTwoClasses() {
        var original = new OriginalClass();
        var derivedClass = new DerivedClass();
    
        original.CompareExecutions(
            derivedClass,
            new[] {
                new {One = "First", Two=1},
                new {One = "Second", Two=2},
                new {One = "Third", Two=3}
            },
            (c,p) => c.MyMethod(p.One, p.Two)
        );
    }
