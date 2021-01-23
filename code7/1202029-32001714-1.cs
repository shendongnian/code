    var paramId = new SqlParameter
    {
        ParameterName = "id",
        SqlDbType = SqlDbType.Xml,
        Direction = ParameterDirection.Input,
        Value = 1
    };
    var paramXmlResult = new SqlParameter
    {
        ParameterName = "XmlResult",
        SqlDbType = SqlDbType.Xml,
        Direction = ParameterDirection.Output
    };
    db.Database.SqlQuery<XElement>(
        "EXEC [dbo].[GetDataAsXml] @id, @XmlResult OUT", 
        paramId, paramXmlResult).ToList();
  
    XElement xmlResult = XElement.Parse(paramXmlResult.Value.ToString());
    //FromXElement is an Extension method that deserializes XML into a Type (like MyData)
    MyData data = xmlResult.FromXElement<MyData>();
