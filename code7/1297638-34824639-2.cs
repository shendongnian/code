    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("Baza_de_cunostinte.xml");
        
        var dataSource = new List<Persoane>();
        string PersoanaPlacuta;
        
        
         XmlNodeList xmlNodeList = doc.SelectNodes("//root//Persoane");
         foreach (XmlNode node in xmlNodeList)
         {
            string PersoanaPlacuta = node.ChildNodes[3].InnerText.Replace("\"", "");
            comboBox1.Items.Add(PersoanaPlacuta);
         }
    }
