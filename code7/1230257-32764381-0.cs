    namespace ConsoleApplication2
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public sealed class FileField : Attribute
        {
            public int Index { get; set; }
            public FileField() { }
        }
        class ExampleClass
        {
            [FileField(Index = 0)]
            public string meaningfulName1 { get; set; }
            [FileField(Index = 2)]
            public double meaningfulName2 { get; set; }
            [FileField(Index = 1)]
            public MyOtherClass meaningfulNameN { get; set; }
        }
        class MyOtherClass
        {
            public string Something { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var exampleClassFieldProperties = GetExampleClassFieldProperties();
                var lines = File.ReadAllLines("datafile.txt");
                var records = new List<ExampleClass>();
                foreach (var line in lines)
                {
                    var fields = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var record = new ExampleClass();
                    for(int fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
                    {
                        if (exampleClassFieldProperties.ContainsKey(fieldIndex))
                        {
                            ReadValueFromFile(fields[fieldIndex], exampleClassFieldProperties[fieldIndex], record);
                        }
                    }
                    records.Add(record);
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            public static Dictionary<int, PropertyInfo> GetExampleClassFieldProperties()
            {
                var exampleClassFieldProperties = new Dictionary<int, PropertyInfo>();
                var properties = typeof(ExampleClass).GetProperties();
                foreach (var property in properties)
                {
                    var attributes = property.GetCustomAttributes(false);
                    int index = 0;
                    foreach (var attribute in attributes)
                    {
                        if (attribute is FileField)
                        {
                            index = ((FileField)attribute).Index;
                            if (exampleClassFieldProperties.ContainsKey(index) == false)
                            {
                                exampleClassFieldProperties.Add(index, property);
                            }
                        }
                    }
                }
                return exampleClassFieldProperties;
            }
            public static void ReadValueFromFile(string field, PropertyInfo exampleClassField, ExampleClass record)
            {
                if (exampleClassField.PropertyType.Name == typeof(string).Name)
                {
                    record.GetType().InvokeMember(exampleClassField.Name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
                        Type.DefaultBinder, record, new object[] { field });
                }
                else if (exampleClassField.PropertyType.Name == typeof(double).Name)
                {
                    record.GetType().InvokeMember(exampleClassField.Name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
                        Type.DefaultBinder, record, new object[] { double.Parse(field) });
                }
                else if (exampleClassField.PropertyType.Name == typeof(MyOtherClass).Name)
                {
                    var other = new MyOtherClass();
                    // TO DO: Parse field to set properties in MyOtherClas
                    record.GetType().InvokeMember(exampleClassField.Name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
                        Type.DefaultBinder, record, new object[] { other });
                }
            }
        }
    }
