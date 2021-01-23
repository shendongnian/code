    using (Stream fos = File.Open(@"C:\Foo.dbf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
        var writer = new DBFWriter();
        var field = new DBFField("Foo1", NativeDbType.Numeric, 15, 0);
        writer.Fields = new[] { field };
    
        writtenValue = 123456789012345L;
        writer.AddRecord(writtenValue);
        writer.Write(fos);
    }
