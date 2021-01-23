    using System.Xml;
    using System.Data;
     XmlReader xmlFile ;
                    xmlFile = XmlReader.Create("examplefile1.xml", new XmlReaderSettings());
                    DataSet ds = new DataSet();
                    ds.ReadXml(xmlFile);
                    dataGridView1.DataSource = ds.Tables[0];
