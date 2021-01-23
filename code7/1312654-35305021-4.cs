    var c = new Derived2Getter<Cc, Bb, Aa>();
    Console.WriteLine(c.Get() is Cc);
    var d = (IGetThing<Bb>)c;
    Console.WriteLine(d.Get() is Cc);
    var e = (IGetThing<Aa>)c;
    Console.WriteLine(e.Get() is Cc);
    var f = new DerivedGetter<Dd, Aa>();
