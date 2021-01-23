    public static void WorkWithT<T>() where T : new()
    {
        Generic<T> g = new Generic<T>();
        T obj = g.Create();
        Console.WriteLine(g.IsArray());
    }
    var method = typeof(Program).GetMethod("WorkWithT").MakeGenericMethod(field.FieldType);
    // Single reflection use. Inside WorkWithT no reflection is used.
    method.Invoke(null, null); 
