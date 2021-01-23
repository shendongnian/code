    public class Foo{}
    public class Foo1 : Foo {}
    public class Foo2 : Foo {}
    public class Foo12 : Foo1 {}
    public calls A<T1,T2> where T1: Foo where T2 : T1 {}
