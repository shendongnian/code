    string path = @"MyPathTo\Package.dtsx";
    XNamespace dts = "www.microsoft.com/SqlServer/Dts";
    XDocument doc = XDocument.Load(path);
    
    // get all connections
    var connections = from ele in doc.Descendants(dts + "ConnectionManager")
                      where ele.Attributes(dts + "ObjectName").Count() != 0
                      select ele;
    
    foreach (var connection in connections)
    {
        // look for your flat file connection
        if (connection.Attribute(dts + "ObjectName").Value == "Flat File Connection Manager")
        {
            var connectionDetails = connection.Element(dts + "ObjectData").Element(dts + "ConnectionManager");
            Console.WriteLine("CodePage: " + connectionDetails.Attribute(dts + "CodePage").Value);
            Console.WriteLine("Unicode: " + connectionDetails.Attribute(dts + "Unicode").Value);
            var columnList = connection.Descendants(dts + "FlatFileColumn");
            foreach (var column in columnList)
            {
                Console.WriteLine("Column name: " + column.Attribute(dts + "ObjectName").Value);
                Console.WriteLine("Column type: " + column.Attribute(dts + "DataType").Value);
            }
        }
    }
