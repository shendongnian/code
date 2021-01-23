    var currentAssembly = typeof(App).GetTypeInfo().Assembly; 
    var customAttributes = currentAssembly.CustomAttributes; 
    var list = customAttributes.ToList(); 
    var res = list[0]; 
    var result = list.FirstOrDefault(x => x.AttributeType.Name == "AssemblyFileVersionAttribute"); 
    var ver = result.ConstructorArguments[0].Value;
