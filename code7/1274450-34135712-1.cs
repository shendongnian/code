    using (CsvWriter writer = new CsvWriter("users.csv"))
    using (XmlRecordReader reader = new XmlRecordReader("users.xml", "users/user"))
    {
	reader.Columns.Add("field", "field");
	reader.Columns.Add("something", "something");
	reader.Columns.Add("name", "name");
	writer.Write("field");
	writer.Write("something");
	writer.Write("name");
	writer.EndRecord();
	while (reader.ReadRecord())
	{
		writer.Write(reader["field"]);
		writer.Write(reader["something"]);
		writer.Write(reader["name"]);
		writer.EndRecord();
	}
	reader.Close();
	writer.Close();
    }
