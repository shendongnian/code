     public static DataSet ConverttYourXmlNodeToDataSet(XmlNode xmlnodeinput)
        {
            //declaring data set object
            DataSet dataset = null;
            if (xmlnodeinput != null)
            {
                NameTable nt = new NameTable();
                nt.Add("row");
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
                XmlParserContext context = new XmlParserContext(nt, null, "heb",null, null, null, null, null, XmlSpace.None,Encoding.Unicode);
                String s = xmlnodeinput.OuterXml.Replace("ows__x05e9__x05dd__x0020__x05de__x05", "AccountManager");
               
                XmlTextReader xtr = new XmlTextReader(s, XmlNodeType.Element,context);
            
                dataset = new DataSet();
                
                dataset.ReadXml(xtr);
            }
            return dataset;
        }
