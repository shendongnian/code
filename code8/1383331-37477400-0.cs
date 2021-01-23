    private String path= @"C:\Temp\xml.xml"; //YOur XML path
    public string getValue(string Name)
    {
        try
        {
            doc = XDocument.Load(path);
            var dada = (from c in doc.Descendants(Name)
                        where c.Parent.Name!=Name
                        select c).First();
            return dada.Value;
        }
        catch (Exception)
        {
            global::System.Windows.Forms.MessageBox.Show("There was a problem with the XML");
            return "";
        }
    }
