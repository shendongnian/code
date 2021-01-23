    public static DataTable LoadDataTableFromXML(string Path)
    {
          XmlDocument doc = new XmlDocument(); /* using System.Xml */
          doc.Load(Path);
          DataSet dataSet = new DataSet();
          dataSet.ReadXml(new StringReader(doc.InnerXml));
          return dataSet.Tables[0];
    }
