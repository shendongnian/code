    var dt = new DataTable("dt"); // short table name
    // mapping to attribute
    dt.Columns.Add("Name").ColumnMapping = MappingType.Attribute;
    dt.Columns.Add("Value").ColumnMapping = MappingType.Attribute;
    dt.Rows.Add("name1", "value1");
    dt.Rows.Add("name2", "value2");
    dt.WriteXml("test.xml");
