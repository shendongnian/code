    Each call to "new" would create a new instance of the class "SomeBase". So in your case, these two lines would create two new instances .
    
    <code>public static SomeBase someBaseField = GetBase(someBool);
    public static SomeBase someBaseProperty { get { return GetBase(someBool); } }
    </code>
    
    Please note that, in both the cases , you are only making the references as static. static references have no impact on object creation.
    
    If you want to create a single object only, add a null check in GetBase() like following :
    
    <code>
    if (someBaseProperty == null)
    {
     someBaseProperty = new SomeObjectA() as SomeBase; 
     return someBaseProperty;
    }
    else {
    return someBaseProperty;
    }
    </code>
    
    And there is no need to expose the Filed as a public.
