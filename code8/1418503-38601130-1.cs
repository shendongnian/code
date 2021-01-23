    void Main(){
        new A().Bar();
        new A().Foo(a=>a.AProp == 0);
        new A().Foo(a=>false);
        new Container<A>().Bar();
        new Container<A>().Foo(a=>a.AProp == 0);
        new Container<A>().Foo(a=>false); // yay, works now!
    }
    interface IMarker<T>{
        T Source{get;}
    }
    class A : IMarker<A>{
        public int AProp {get;set;}
        public A   Source{get{return this;}}
    }
    class B : IMarker<B>{
        public int BProp {get;set;}
        public B   Source{get{return this;}}
    }
    class Container<T> : IMarker<T>{
        public T Source{get;set;}
    }
    static class Extensions{
        public static void Foo<T>(this IMarker<T> t, Func<T, bool> func){}
        public static void Bar<T>(this IMarker<T> t){}
    }
