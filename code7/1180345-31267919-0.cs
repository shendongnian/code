	static void Main(string[] args)
	{
		var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly
                        (new AssemblyName("TestAssembly"), AssemblyBuilderAccess.Run);
		var module = assembly.DefineDynamicModule("Main");
		var type = module.DefineType("Test");
		var method = type.DefineMethod
                      (
                        "Test", MethodAttributes.Public | MethodAttributes.Static, 
                        typeof(int), new[] { typeof(string) }
                      );
		var gen = method.GetILGenerator();
		gen.Emit(OpCodes.Jmp, typeof(Class1).GetMethod("Test"));
		var obj = Activator.CreateInstance(type.CreateType());
						
		var func = (Func<string, int>)
                    obj.GetType().GetMethod("Test").CreateDelegate(typeof(Func<string, int>));
		var result = func("Banana");
		Console.WriteLine(result);
		Console.ReadLine();
	}
