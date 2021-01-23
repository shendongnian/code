    string s = "<Tables>" +
                    "<Table name='Test1'>" +
                    "<tablename>TestTable</tablename>" +
                    "<refTable>NULL</refTable>" +
                    "<refTableIDColumn>NULL</refTableIDColumn>" +
                    "</Table>" +
                    "<Table name='Test2'>" +
                    "<tablename>OutlineURL</tablename>" +
                    "<refTable>TestTable</refTable>" +
                    "<refTableIDColumn>TestTableID</refTableIDColumn>" +
                    "</Table>" +
                    "<Table name='Test3'>" +
                    "<tablename>OutlineSummary</tablename>" +
                    "<refTable>TestTable</refTable>" +
                    "<refTableIDColumn>TestTableID</refTableIDColumn>" +
                    "</Table>" +
                    "<Table name='Test4'>" +
                    "<tablename>TestForm</tablename>" +
                    "<refTable>TestTable</refTable>" +
                    "<refTableIDColumn>TestTableID</refTableIDColumn>" +
                    "</Table>" +
                "</Tables>";
    var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(s)); ;
    System.Xml.Linq.XDocument myxml = System.Xml.Linq.XDocument.Load(ms);
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(myxml.ToString());
    XmlNodeList xnList = doc.SelectNodes("/Tables/Table[@name='Test2']");
    foreach (XmlNode xn in xnList) {
        var dummy = xn.OuterXml;
    }
