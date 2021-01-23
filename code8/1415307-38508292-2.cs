    var usesInheritedClass = new MyCov<InheritedClass>();
    
    //This is legal, because the type parameter in ICov is covariant
    ICov<BaseClass> usesBaseClass = usesInheritedClass;
    //Here's where it goes bad.
    usesBaseClass.ListOfT.Add(new BaseClass());
    
