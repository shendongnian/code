    public static void StructTest()
    {
        var fooStruct = new MyStruct();
        var barStruct = new MyStruct();
            
        Console.WriteLine(fooStruct.Value); // prints 0
        Console.WriteLine(barStruct.Value); // prints 0
    
        fooStruct(ref fooStruct);
        barStruct(barStruct);
    
        // Struct value only changes when passed by reference.
        Console.WriteLine(fooStruct.Value); // prints 1
        Console.WriteLine(barStruct.Value); // prints 0    
    }
    public void fooStruct(ref MyStruct m) 
    {
        m.Value++;
    }
    
    public void barStruct(MyStruct m)
    {
        m.Value++;
    }
    public static void ObjectTest()
    {
        var fooObject = new MyObject();
        var barObject = new MyObject();
    
        Console.WriteLine(fooObject.Value); // prints 0
        Console.WriteLine(barObject.Value); // prints 0
    
        fooObject(ref fooObject);
        barObject(barObject);
    
        // Objects are automatically passed by reference. No difference.
        Console.WriteLine(fooObject.Value); // prints 1
        Console.WriteLine(barObject.Value); // prints 1
        
        fooSetObjectToNull(ref fooObject);
        barSetObjectToNull(barObject);
        
        // Reference is actually a pointer to the variable that holds a reference to the object.
        Console.WriteLine(fooObject == null); // prints true
        Console.WriteLine(barObject == null); // prints false
    }   
    
    public void fooObject(ref MyObject m)
    {
        m.Value++;
    }
    
    public void barObject(ref MyObject m)
    {
        m.Value++;
    }
    public void fooSetObjectToNull(ref MyObject m)
    {
        m = null;
    }
    public void barSetObjectToNull(MyObject m)
    {
        m = null;
    }
