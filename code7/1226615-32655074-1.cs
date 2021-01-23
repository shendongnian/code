    // in A.dll
    public dynamic Method() {
        return new ClassFromB(); // thing from B.dll
    }
    // in your app:
    // do not ever explicitely name ANY type from:
    dynamic foo = ClassFromA.Method();
    dynamic result = foo.CallSomething(1,2,3); // even when getting results
    dynamic other = result.Boom(foo); // and even when passing params
