    void Main()
    {
        var a = new DerivedClass();
        var b = new DerivedClass();
        //The generic parameters in order are:
        //1. The type which implements the desired method
        //2. The type of the arguments (a and b)
        //3. The parameter argument of the method (object vs DerivedClass)
        //The following three are equivelant, using 'default' generic arguments
        MyComparerThing<DerivedClass>.Equals(a, b);
        MyComparerThing<DerivedClass, DerivedClass>.Equals(a, b);
        MyComparerThing<DerivedClass, DerivedClass, object>.Equals(a, b);
        //This will print the method declared in BaseClass. a and b are still DerivedClass instances. This is the one you're wanting to use
        MyComparerThing<BaseClass, DerivedClass>.Equals(a, b);
        
        //This will print the method declared in DerivedClass, with the DerivedClass overload
        MyComparerThing<DerivedClass, DerivedClass, DerivedClass>.Equals(a, b);
        
        //This will print the method declared in DerivedClass, with the object overload
        MyComparerThing<DerivedClass, DerivedClass, object>.Equals(a, b);
        
    }
