    foreach (XmlNode column in xml.SelectNodes(
        "/Data/Collection[@name='CORALL']/SubCollection/Column[@name='EX_ID' and starts-with(., 'h')]"))
    {
        // Column.SubCollection.Collection.RemoveChild(Column.SubCollection)
        column.ParentNode.ParentNode.RemoveChild(column.ParentNode);
    }
