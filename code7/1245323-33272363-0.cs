    void Main(){
        //This is the existing assembly containing the type that you wish to modify
    	var assemblyFile = @"C:\temp\ExistingAssembly.dll";
    	
    	var ass = Mono.Cecil.AssemblyDefinition.ReadAssembly(assemblyFile);
    	var type = ass.MainModule.GetTypes().First(t => t.Name == "Test");
        //Make the type an Abstract type (class)
    	type.IsAbstract = true;
        //Finally save the modified assembly into a new file
    	ass.Write(@"C:\temp\ModifiedAssembly.dll");
    
        //The type "Test" in the above "ModifiedAssembly.dll" is now an abstract class.
    }
    
    // This is the Type that you wish to turn into an Abstract Class
    public class Test {
    	public string DummyMethod(){
    		return "Dummy Return";
    	}
    }
