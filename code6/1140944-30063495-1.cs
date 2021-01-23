    private static void PrintFieldsForType(ClrRuntime runtime, string targetType)
    {
        ClrHeap heap = runtime.GetHeap();
        foreach (var ptr in heap.EnumerateObjects())
        {
            ClrType type = heap.GetObjectType(ptr);
            if (type.Name == targetType)
            {
                foreach(var field in type.Fields)
                {
                    if (field.HasSimpleValue)
                    {
                        object value = field.GetFieldValue(ptr);
                        Console.WriteLine("{0} ({1}) = {2}", field.Name, field.Type.Name, value);
                    }
                    else
                    {
                        Console.WriteLine("{0} ({1})", field.Name, field.Type.Name);
                    }
                }
            }
        }
    }
