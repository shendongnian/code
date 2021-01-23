    // <Name>Base class should not use derivatives</Name>
            
    warnif count > 0 
    from baseClass in JustMyCode.Types
    where baseClass.IsClass && baseClass.NbChildren > 0 // <-- for optimization!
    let derivedClassesUsed = baseClass.DerivedTypes.UsedBy(baseClass)
    where derivedClassesUsed.Count() > 0
    select new { baseClass, derivedClassesUsed }
    
    //<Description>
    // In *Object-Oriented Programming*, the **open/closed principle** states:
    // *software entities (components, classes, methods, etc.) should be open 
    // for extension, but closed for modification*. 
    // http://en.wikipedia.org/wiki/Open/closed_principle
    //
    // Hence a base class should be designed properly to make it easy to derive from,
    // this is *extension*. But creating a new derived class, or modifying an
    // existing one, shouldn't provoke any *modification* in the base class.
    // And if a base class is using some derivative classes somehow, there
    // are good chances that such *modification* will be needed.
    //
    // Extending the base class is not anymore a simple operation,
    // this is not good design.
    //</Description>
    
    //<HowToFix>
    // Understand the need for using derivatives, 
    // then imagine a new design, and then refactor.
    //
    // Typically an algorithm in the base class needs to access something 
    // from derived classes. You can try to encapsulate this access behind 
    // an abstract or a virtual method.
    //
    // If you see in the base class some conditions on *typeof(DerivedClass)*
    // not only *urgent refactoring* is needed. Such condition can easily 
    // be replaced through an abstract or a virtual method.
    //
    // Sometime you'll see a base class that creates instance of some derived classes.
    // In such situation, certainly using the *factory method pattern* 
    // http://en.wikipedia.org/wiki/Factory_method_pattern
    // or the *abstract factory pattern* 
    // http://en.wikipedia.org/wiki/Abstract_factory_pattern
    // will improve the design. 
    //</HowToFix>
