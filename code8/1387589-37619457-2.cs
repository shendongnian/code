    public static Type CreateProperty(string value)
    {
        string code = @"
        namespace UserFunctions
        {                
                public class MyProperty
                {          
                private string name = my_value
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
        code = code.Replace("my_value", '"' + value + '"');
        CSharpCodeProvider provider = new CSharpCodeProvider();
        CompilerResults results = provider.CompileAssemblyFromSource(new CompilerParameters(), code);
        Type myProperty = results.CompiledAssembly.GetType("UserFunctions.MyProperty");
        return myProperty;
    }
    static void Main()
    {
        Type propertyType = CreateProperty("this is a value");
        var property = propertyType.GetProperty("Name");
        var instance = Activator.CreateInstance(propertyType);
        Console.WriteLine(property.GetValue(instance, null));
        property.SetValue(instance, "MyNewValue", null);            
        Console.WriteLine(property.GetValue(instance, null));
    }
