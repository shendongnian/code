    private static void PrintFieldsForType(ClrRuntime runtime, TextWriter writer, string targetType)
    {
        ClrHeap heap = runtime.GetHeap();
        foreach (var ptr in heap.EnumerateObjects())
        {
            ClrType type = heap.GetObjectType(ptr);
            if (type.Name == targetType)
            {
                writer.WriteLine("{0}:", targetType);
                PrintFields(type, writer, ptr, 0);
            }
        }
    }
    private static void PrintFields(ClrType type, TextWriter writer, ulong ptr, int indentLevel)
    {
        string indent = new string(' ', indentLevel * 4);
        foreach (var field in type.Fields)
        {
            writer.Write(indent);
            if (field.IsObjectReference() && field.Type.Name != "System.String")
            {
                writer.WriteLine("{0} ({1})", field.Name, field.Type.Name);
                ulong nextPtr = (ulong)field.GetFieldValue(ptr);
                PrintFields(field.Type, writer, nextPtr, indentLevel + 1);
            }
            else if (field.HasSimpleValue)
            {
                object value = field.GetFieldValue(ptr);
                writer.WriteLine("{0} ({1}) = {2}", field.Name, field.Type.Name, value);
            }
            else
            {
                writer.WriteLine("{0} ({1})", field.Name, field.Type.Name);
            }
        }
    }
