    public class A { public B BInstance { get; set; } }
    public class Z { public B BInstance { get; set; } }
    public class C { public Z BInstance { get; set; } }
    public class B
    {
        public List<Type> GetParentTypes()
        {
            Type thisType = this.GetType();
            FieldInfo f = null;
            PropertyInfo p = null;
            Assembly assembly = Assembly.GetAssembly(thisType);
            List<Type> types = 
                assembly.DefinedTypes
                .Where(t => t.IsClass
                    && t.GetMembers().Any(m =>
                {
                    if ((f = m as FieldInfo) != null)
                        return f.FieldType == thisType;
                    return (p = m as PropertyInfo) != null &&
                                     p.PropertyType == thisType;
                }))
                .Select(t => t.AsType())
                .ToList();
            return types;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B instance = new B();
            List<Type> types = instance.GetParentTypes();
            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
            }
        }
    }
