    private List<APISAVE> list = null;
    static void main(string[] args)
    {
        list = new List<APISAVE>();
        var doc = XDocument.Load("data.XML");
            
        foreach (XElement element in doc.Descendants("APISAVE"))
        {
            list.Add(new APISAVE() { ID = element.Element("ID").Value, APIKEY = element.Element("APIKEY").Value, VCODE = element.Element("VCODE").Value });
        }
    }       
    public static void SaveData(object obj, string Filename)
    {   
        list.Add(obj) // APISAVE objec
        // Serialize the list
        XmlSerializer sr = new XmlSerializer(list.GetType());
        TextWriter writer = new StreamWriter(Filename, true);
        sr.Serialize(writer, list);
        writer.Close();
    }
