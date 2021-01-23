    [HttpPost]
    public XmlElement getClassXml(HttpRequestMessage req)
    {
        var response = Request.CreateResponse(HttpStatusCode.OK);
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        ClassXML classid = new ClassXML();
        XmlDocument doc = new XmlDocument();
        try
        {
            var data = req.Content.ReadAsStringAsync().Result;
            classid = serializer.Deserialize<ClassXML>(data.ToString().Trim());
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
        string path = ASDb.ReadValue("SELECT definitionxml FROM alclass WHERE classid='" + classid.classID + "'").ToString();
         XmlTextReader reader = new XmlTextReader(AppDomain.CurrentDomain.BaseDirectory + "Resource\\" + percorso);
         reader.Read();
         doc.Load(reader);
         XmlElement element = doc.DocumentElement;
         return element;
    }
