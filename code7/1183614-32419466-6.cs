    dynamic expando = new ExtendedExpandoObject();
    Console.WriteLine(expando.Value);          // the original expando
    expando.Length = 12;                       // set a new property on the expando
    Console.WriteLine(expando.Length);         // get a property on the expando
    Console.WriteLine(expando.GetMessage());   // call the new method
    Console.WriteLine(expando.GetTypeName<ExtendedExpandoObject>());  // call the generic method
    Console.WriteLine(expando.Value.Length);   // get the property on the original expando
