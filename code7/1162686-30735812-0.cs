    public class Foo {
    
        [Import]
        private SomeExportedType foobar;
    
        [Import]
        private Bar bar;
    
        public Foo() {
            foobar.Test(); // Works just 
    
            bar.Test(); // Should also work fine.
        }
    }
