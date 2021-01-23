    public void ChangeMethodName()
    {
        //Before changing the method name
        var assem = Assembly.LoadFile(@"C:\temp\ClassLibrary1.dll");
        Console.WriteLine(
            assem.GetType("ClassLibrary1.Class1").
            GetMethod("Start", BindingFlags.Static | BindingFlags.Public).
            Invoke(null, null));
        // Change the name
        var module = ModuleDefinition.ReadModule(@"C:\temp\ClassLibrary1.dll");
        TypeDefinition myType = 
            module.Types.First(type => type.Name == "Class1");
        var method = myType.Methods.First(m => m.Name == "Start");
        method.Name = "###Start_v1.4.3.0";
        module.Write(@"C:\temp\ClassLibrary1_new.dll");
        //After changing the method name
        assem = Assembly.LoadFile(@"C:\temp\ClassLibrary1_new.dll");
        Console.WriteLine(
            assem.GetType("ClassLibrary1.Class1").
            GetMethod("###Start_v1.4.3.0",
                      BindingFlags.Static|BindingFlags.Public).
            Invoke(null, null));
    }
    public class Class1
    {
        public static string Start()
        {
            return $"my name is {MethodBase.GetCurrentMethod().Name}";
        }
    }
