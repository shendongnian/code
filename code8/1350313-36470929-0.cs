    xmlFile = XmlReader.Create("navetout.xml", new XmlReaderSettings());
           
    
    ds.ReadXml(xmlFile);
    
    
    connection.Open();
    
    SqlCommand command1 = new SqlCommand("INSERT INTO Seamen(FirstName) values(@FirstName)", connection);
    
    foreach (var name in First)
    {
    	command1.Parameters.Clear();
        command1.Parameters.AddWithValue("@FirstName", name);
    
        command1.ExecuteNonQuery();
    }
    
    connection.Close();
    Console.WriteLine("Done");
