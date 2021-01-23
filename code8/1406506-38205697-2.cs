    Foo foo1;
    if(foo != null)
    {
        foo1 = foo.Identity().Value;  // not possible - Foo has no Value property.
    }
    else
    {
        foo1 = null;  // also not possible 
    }
    Foo foo2;
    Foo? temp;
    if(foo != null)
    {
        temp = foo.Identity();
    }
    else
    {
       temp = null;  // actually a Nullable<Foo> with no value
    }
    foo2 = temp.Value;  // legal, but will throw an exception at run-time if foo is null
