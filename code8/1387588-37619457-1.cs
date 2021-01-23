    public static Type CreateProperty(string value)
    {
        string code = @"
    namespace UserFunctions
    {                
            public class MyProperty
            {          
            private string name = {0}
            public string Name {
                get{
                    return this.name;
                }
                set{
                    this.name=value;
                }
            }
        }
    }
    ";
        code = string.Format(code, '"' + value + '"');
        CSharpCodeProvider provider = new CSharpCodeProvider();
        CompilerResults results = provider.CompileAssemblyFromSource(new CompilerParameters(), code);
        Type myProperty = results.CompiledAssembly.GetType("UserFunctions.MyProperty");
        return myProperty;
    }
    [STAThread]
    static void Main()
    {
        Type propertyType = CreateProperty("this is a value");
        var property = propertyType.GetProperty("Name");
        var instance = Activator.CreateInstance(propertyType);
        property.SetValue(instance, "MyNewValue", null);
    }
