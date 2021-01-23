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
     private void button1_Click(object sender, EventArgs e)
     {
        try
        {
    
    
            APISAVE info = new APISAVE();
            info.APIKEY = txtAPI.Text;
            info.VCODE = txtVerC.Text;
            info.ID = info.ID;
            list.Add(info);
            APISAVE.SaveData(list, "data.XML");
    
        }
    
        catch (Exception ex)
    
        {
            MessageBox.Show(ex.Message);
        }
    } 
     
    public static void SaveData(List<APISAVE> list, string Filename)
    {   
        // Serialize the list
        XmlSerializer sr = new XmlSerializer(list.GetType());
        TextWriter writer = new StreamWriter(Filename, true);
        sr.Serialize(writer, list);
        writer.Close();
    }
