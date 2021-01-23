        public DataTable ReadXML(string file)
    {
        DataTable table = new DataTable("XmlData");
        Stream stream = new  FileStream(file, FileMode.Open, FileAccess.Read);
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Power", typeof(int));
        table.Columns.Add("Location", typeof(string));
        table.ReadXml(stream);
        return table;
    }
