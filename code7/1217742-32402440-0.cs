    public class Foo2<T1, T2> : Foo1<T1>
    {
        public Foo2(Func<IFoo<T1>, T1, T2, T1> newPostRead, Func<T2> resolver)
    	    :base((IFoo<T1> t1a, T1 t1b) => newPostRead(t1a, t1b, resolver() ))
        {
        }
    }
