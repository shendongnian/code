    unsafe void Foo() {
        
        Byte[] safeArray = new Byte[ 50 ];
        safeArray[0] = 255;
        Byte* p = &safeArray[0];
        
        Console.WriteLine( "Array address: {0}", &safeArray );
        Console.WriteLine( "Pointer target: {0}", p );
        // These will both print "0x12340000".
        
        while( executeTightLoop() ) {
            Console.WriteLine( *p );
            // valid pointer dereferencing, will output "255".
        }
        
        // Pretend at this point that GC ran right here during execution. The safeArray object has been moved elsewhere in memory.
        
        Console.WriteLine( "Array address: {0}", &safeArray );
        Console.WriteLine( "Pointer target: {0}", p );
        // These two printed values will differ, demonstrating that p is invalid now.
        Console.WriteLine( *p )
        // the above code now prints garbage (if the memory has been reused by another allocation) or causes the program to crash (if it's in a memory page that has been released, an Access Violation)
    }
    
