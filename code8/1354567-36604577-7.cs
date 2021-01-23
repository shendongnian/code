    var foos = new Foo[] { null, null, null };
    var iFoos = new IFoo[3];
    Array.Copy(foos, iFoos, 3); //reference conversion
            
    var ints = new[] { 1, 2, 3 };
    var objs = new object[3];
    Array.Copy(ints, objs, 3); //boxing conversion
    Array.Copy(objs, ints, 3); //unboxing conversion
