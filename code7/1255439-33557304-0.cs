    public interface Foo { void FooMethod(); }
    public interface Bar { void BarMethod(); }
    public interface Baz : Foo, Bar { }
    public class Qux : Baz
    {
        void Foo.FooMethod() { } // legal
        public void BarMethod() { }
    }
