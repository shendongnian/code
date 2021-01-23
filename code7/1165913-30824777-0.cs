    // Check initial memory
    var memoryStart = System.GC.GetTotalMemory(true);
             
    // Allocate an object.
    var myClass = new SomeClass;
    // Check memory after allocation
    var memoryEnd = System.GC.GetTotalMemory(true);
