    public class Bar : Foo
    { 
        public Bar(int a, int b) : Foo(a, b) {}
    }
    // ...
    List<Bar> list;
 
    // ...
    list.Add({1,2});
