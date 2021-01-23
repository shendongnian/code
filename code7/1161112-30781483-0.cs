    public class MyGeneric<T>
    {
        public static void trigger(IList<T> result)
        {
            // do generic stuff where
            // you do not need to know T
        }
    }
    // this class does only explicit Foo related stuff
    public class MyNONEGeneric 
    {
        public static void trigger(IList<Foo> list)
        {
             // do some 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PersistentGenericBag<Foo> magicBag = myMagic<Foo>();
             // call your generic which do some general list related stuff
             MyGeneric<Foo>.trigger(list);
             // call your none generic which do some foo related stuff
             MyNONEGeneric.trigger(list);
        }
    }
