    CodeCompileUnit codeUnit = new CodeCompileUnit();
    CodeNamespace codeNamespace = new CodeNamespace();
    codeUnit.Namespaces.Add(codeNamespace); // Add additional Namespaces
    ServiceDescriptionImportWarnings importWarnings = descriptionImporter.Import(codeNamespace, codeUnit);
    if (importWarnings == 0)
    {
          using (CodeDomProvider compiler = CodeDomProvider.CreateProvider("CSharp"))
          {
               string[] references = { "System.dll", "System.Web.Services.dll", "System.Xml.dll" };
               CompilerParameters parameters = new CompilerParameters(references); 
               parameters.GenerateExecutable = false;
               parameters.GenerateInMemory = false;
               parameters.IncludeDebugInformation = false;
               parameters.CompilerOptions = "/optimize";
               parameters.TempFiles = new TempFileCollection(System.IO.Path.GetTempPath() + "xxx", false);
               parameters.ReferencedAssemblies.Add("System.dll");
               results = compiler.CompileAssemblyFromSource(parameters, CSharpCode);
               foreach (CompilerError cError in results.Errors)
               {
                   // log errors
               }
               if (results.Errors.Count > 0 || results.CompiledAssembly == null) throw new Exception("Kompilierfehler bei Assemblyerstellung");
           }
     }
