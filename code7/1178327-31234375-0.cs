    class MainClass
    {
    	public static void TestMethod() {
    		return;
    	}
    
    	public static void Main (string[] args)
    	{
    		// Load mscorlib.dll
    		string filename = typeof(void).Module.FullyQualifiedName;
    		ModuleDefMD mod = ModuleDefMD.Load(Assembly.GetExecutingAssembly().Location);
    
    		foreach (TypeDef type in mod.GetTypes()) {
    			Console.WriteLine("Type: {0}", type.FullName);
    
    			foreach (var method in type.Methods) {
    				using (var reader =  mod.MetaData.PEImage.CreateFullStream()) {
    					reader.Position = (long)mod.MetaData.PEImage.ToFileOffset(method.RVA);
    					var flags = reader.ReadByte ();
    					Console.WriteLine (" Method: {0}, Tiny: {1}", method.Name, (flags & 3) == 2);
    				}
    			}
    		}
    		Console.WriteLine();
    	}
    }
