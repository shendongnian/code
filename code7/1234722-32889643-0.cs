    // your code, practically unchanged
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(result);
    XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
    ns.AddNamespace("SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
    ns.AddNamespace("XZ", "http://schemas.hp.com/SM/7");
    XmlNode node = doc.SelectSingleNode("SOAP-ENV:Envelope/SOAP-ENV:Body/XZ:RetrieveSDToDoListResponse", ns);
    
    if(node!=null)
    {
        //define your table
        DataTable dt = new DataTable();
        dt.Columns.Add("TodoNumber", typeof(string));
        dt.Columns.Add("ToDoModule", typeof(string));
        dt.Columns.Add("ToDoStatus", typeof(string));
        dt.Columns.Add("ToDoDescription", typeof(string));
        dt.Columns.Add("ToDoAssignmentGroup", typeof(string));
        dt.Columns.Add("ToDoAssigneeName", typeof(string));
        dt.TableName = "instance";
    
        string content = "<DocumentElement>" +
            //DIRTY HACK TO REMOVE NAMESPACE
                node.InnerXml.Replace("xmlns=\"http://schemas.hp.com/SM/7\"", "")
             + "</DocumentElement>";
            
        //this code makes the trick
        using(MemoryStream  ms=new MemoryStream(Encoding.UTF8.GetBytes (content)))
        {
            dt.ReadXml(ms);    
        }
        
    }        
