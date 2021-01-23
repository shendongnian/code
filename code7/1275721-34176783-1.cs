    using Microsoft.CSharp;
    
    [...]
    
    var compiler = new CSharpCodeProvider();
    var type = new CodeTypeReference(typeof(Int32));
    Console.WriteLine(compiler.GetTypeOutput(type)); // Prints int
