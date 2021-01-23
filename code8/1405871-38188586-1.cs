    class Foo {
        public int Value { get; set; }
    }
    class Bar {
        public Foo foo { get; set; }
    }
    Bar bar = new Bar() {
        foo = new Foo() {
            Value = 2
        }
    }
    
    bar.GetPropertyValue("foo.Value"); // 2
    bar.foo = null;
    bar.GetPropertyValue("foo.Value"); // null
