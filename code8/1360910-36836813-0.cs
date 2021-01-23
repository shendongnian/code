    Assembly interfaceLib      = Assembly.ReflectionOnlyLoadFrom( "InterfaceLib.dll" );
    Assembly implementationLib = Assembly.ReflectionOnlyLoadFrom( "ImplementationLib.dll" );
    var i = interfaceLib.GetType( "InterfaceLib.Interface1" );
    var t = implementationLib.GetType( "ImplementationLib.Class1" );
    var b = i.IsAssignableFrom( t );
    Console.WriteLine( b );
    // prints "true"
