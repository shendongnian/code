    StreamWriter sw = new StreamWriter(@".\DemoResources.cs");
      string[] errors = null;
      CSharpCodeProvider provider = new CSharpCodeProvider();
      CodeCompileUnit code = StronglyTypedResourceBuilder.Create("Demo.resx", "DemoResources", 
                                                                 "DemoApp", provider, 
                                                                 false, out errors);    
      if (errors.Length > 0)
         foreach (var error in errors)
            Console.WriteLine(error); 
      provider.GenerateCodeFromCompileUnit(code, sw, new CodeGeneratorOptions());                                         
      sw.Close();
