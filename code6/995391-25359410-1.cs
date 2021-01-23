    public XmlDocument LoadDocument(String path)
    {
        XmlDocument document = new XmlDocument();
        using (StreamReader stream = new StreamReader(path, Encoding.GetEncoding("iso-8859-7")))
        {
            document.Load(stream);
        }
        return (document);
    }
    public XmlDocument SaveDocument(XmlDocument document, String path)
    {
        using (StreamWriter stream = new StreamWriter(path,false,Encoding.GetEncoding("iso-8859-7")))
        {
            document.Save(stream);
        }
        return (document);
    }
    private void savebtn_Click(object sender, EventArgs e)
    {
        var doc = commonMethods.LoadDocument(xml);
        XmlNodeList attributes = doc.DocumentElement.SelectNodes("//Class[@Name='" + classname + "']/Property[@Id='" + id + "']/attribute::*");
        for (int x = 0; x < attributes.Count; )
        {
            foreach (Control ctr in table1.Controls)
            {
                if (ctr is TextBox)
                {
                    if (ctr.Text == attributes[x].Value.ToString()) { x++; }
                    else
                    {
                        attributes[x].Value = ctr.Text; commonMethods.SaveDocument(doc, xml);
                        x++;
                    }
                }
                else if (ctr is ComboBox)
                {
                    if (((ComboBox)ctr).Text == attributes[x].Value) { x++; }
                    else
                    {
                        attributes[x].Value = ((ComboBox)ctr).Text; commonMethods.SaveDocument(doc, xml);
                        x++;
                    }
                }
            }
        }
    }
