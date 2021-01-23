    public void DeserializeXMLColumns()
    {
    	IFormatter formatter = new BinaryFormatter();
    	Stream stream = new FileStream("XMLColumns.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
    	XMLColumns col = (XMLColumns) formatter.Deserialize(stream);
    	stream.Close();
    
    	// Test
    	Console.WriteLine("FieldName: {0}", col.FieldName);
    	Console.WriteLine("CellTemplate: {0}", col.CellTemplate.ToString());
    	Console.WriteLine("GroupValueTemplate: {0}", col.GroupValueTemplate.ToString());
    }
