    private const string CodeTemplate = @"
        namespace XXXX
        {
            public class Surrogate
            {
        ##code##
            }
        }";
    
    public static Type CreateSurrogate(IEnumerable<PropertyInfo> properties)
	{
		var compiler = new CSharpCodeProvider();
		var compilerParameters = new CompilerParameters { GenerateInMemory = true };
		foreach (var item in AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic))
		{
			compilerParameters.ReferencedAssemblies.Add(item.Location);
		}
		
		var propertiesCode = 
			string.join("\n\n", from pi in properties
			                    select "public " + pi.PropertyType.Name + " " + pi.Name + " { get; set; }");
		var source = CodeTemplate.Replace("##code##", propertiesCode);
		var compilerResult = compiler.CompileAssemblyFromSource(compilerParameters, source);
		if (compilerResult.Errors.HasErrors)
		{
			throw new InvalidOperationException(string.Format("Surrogate compilation error: {0}", string.Join("\n", compilerResult.Errors.Cast<CompilerError>())));
		}
		return compilerResult.CompiledAssembly.GetTypes().First(x => x.Name == "Surrogate");
	}
