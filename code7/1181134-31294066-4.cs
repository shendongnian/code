    var xmlstr="<root><Answer_Data><Answer>C1</Answer></Answer_Data>
    <Answer_Data><Answer>C2</Answer></Answer_Data>
    <Answer_Data><Answer>C2</Answer></Answer_Data></root>";
    XDocument xmldoc = XDocument.Parse(xmlstr);
    var groups = from record in xmldoc.Descendants("Answer_Data")
                 group record by (string)record.Element("Answer")  
                 into g
                 select new {
                   key = g.Key,
                   count = g.Count()
                 }
