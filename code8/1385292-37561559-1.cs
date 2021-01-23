    public static XmlNode UpdateListItemInsert()
    {
                listservice.Lists listProxy = new listservice.Lists();
    
                string xml = "<Batch OnError='Continue'><Method ID='1' Cmd='New'><Field Name='ID'/><Field Name='usercol'>-1;#BASESMCDEV2\\testmoss</Field></Method><Method ID='2' Cmd='New'><Field Name='ID'/><Field Name='usercol'>-1;#BASESMCDEV2\\testmoss</Field></Method></Batch>";
    
    
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
    
                XmlNode batchNode = doc.SelectSingleNode("//Batch");
                
    
                listProxy.Url = "http://basesmcdev2/sites/tester1/_vti_bin/lists.asmx";
                listProxy.UseDefaultCredentials = true;
    
                XmlNode resultNode = listProxy.UpdateListItems("custom1", batchNode);
    
                XElement e = XElement.Parse(resultNode.OuterXml);
                var id = from t in e.Descendants().Attributes("ows_ID") select t.Value;
    
    
                return resultNode;
    
    }
