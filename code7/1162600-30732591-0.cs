    var instance = new ClassA();
    var fields = instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
    foreach(var field in fields)
    {
        Console.WriteLine("Field name: {0}. Type:{1} IsGeneric:{2}", field.Name, field.FieldType.Name, field.FieldType.IsGenericType);
        if(field.FieldType.IsGenericType)
        {
            var genericArgs = field.FieldType.GenericTypeArguments;
            foreach(var genericArg in genericArgs)
            {
                Console.WriteLine("\tGenericArg Type:{0}", genericArg.Name);
            }
        }
        
    }
