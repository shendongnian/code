    private void myDoSomething(T e) where T : struct, IConvertible
    {
        if (typeof(T).GetType().Name == "E1")
            DoSomething((E1)(object)e);
        else if (typeof(T).GetType().Name == "E2")
            DoSomething((E2)(object)e);
        else
            throw new ArgumentException();
    }
    
    // private function so users cannot access this generic one
    private void DoEnumStuffTemplate<T>(T e) where T : struct, IConvertible {
        // check type for safety
        if (!typeof(T).IsEnum || typeof(T).GetType().Name != "E1" || typeof(T).GetType().Name != "E2")
            throw new ArgumentException();
        // do lots of stuff
        myDoSomething(e); //<- overloaded function, accepts only E1 and E2 =ERROR
        // do lots of other stuff
    }
