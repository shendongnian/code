    public void VersionInfoExample()
    {
    	// 1. Generate AssemblyInfo.cs-like C# code and parse syntax tree
    	StringBuilder asmInfo = new StringBuilder();
    
    	asmInfo.AppendLine("using System.Reflection;");
    	asmInfo.AppendLine("[assembly: AssemblyTitle(\"Test\")]");
    	asmInfo.AppendLine("[assembly: AssemblyVersion(\"1.1.0\")]");
    	asmInfo.AppendLine("[assembly: AssemblyFileVersion(\"1.1.0\")]");
    	// Product Info
    	asmInfo.AppendLine("[assembly: AssemblyProduct(\"Foo\")]");
    	asmInfo.AppendLine("[assembly: AssemblyInformationalVersion(\"1.3.3.7\")]");
    	var syntaxTree = CSharpSyntaxTree.ParseText(asmInfo.ToString(), encoding: Encoding.Default);
    
    	// 2. Create compilation
    	string mscorlibPath = typeof(object).Assembly.Location;
    	MetadataReference mscorlib = MetadataReference.CreateFromFile(mscorlibPath, new MetadataReferenceProperties(MetadataImageKind.Assembly));
    	CSharpCompilationOptions options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
    
    	CSharpCompilation compilation = CSharpCompilation.Create("Test.dll",
    							references: new[] { mscorlib },
    							syntaxTrees: new[] { syntaxTree },
    							options: options);
    
    	// 3. Emit code including win32 version info
    	using (MemoryStream dllStream = new MemoryStream())
    	using (MemoryStream pdbStream = new MemoryStream())
    	using (Stream win32resStream = compilation.CreateDefaultWin32Resources(
    																versionResource: true, // Important!
    																noManifest: false,
    																manifestContents: null,
    																iconInIcoFormat: null))
    	{
    		EmitResult result = compilation.Emit(
    									 peStream: dllStream,
    									pdbStream: pdbStream,
    									win32Resources: win32resStream);
    
    		System.IO.File.WriteAllBytes("Test.dll", dllStream.ToArray());
    	}
    }
