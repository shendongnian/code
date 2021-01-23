    $ cat > test.cs
    using System;
    
    static class Application {
    	static void Main() {
    		ulong a = 0x8000000000000000;
    		long b = (long)a;
    
    		Console.WriteLine(a);
    		Console.WriteLine(b);
    	}
    }
    $ mcs test.cs
    $ mono test.exe
    9223372036854775808
    -9223372036854775808
