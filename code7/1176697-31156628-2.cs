    public void SerializeXMLColumns()
    {
    	XMLColumns col = new XMLColumns();
        col.FieldName = "Field1";
        col.CellTemplate = new CellTemplate();
        col.GroupValueTemplate = new GroupValueTemplate();
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("MyXMLColumns.bin", FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, col);
        stream.Close();
    }
