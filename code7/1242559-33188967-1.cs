    var results = conn.Query<dynamic>(sql, param);
    var r = new DapperResultSet();
    foreach (var row in results)
    {
        r.Add(row);
    }
    //Here is the serialization part:
    XmlSerializer xs = new XmlSerializer(typeof(DapperResultSet));
    xs.Serialize(new FileStream("Serialized.xml", FileMode.Create), r); //Change path if necessary
