    public void button1_Click(object sender, EventArgs e)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(textBox1.Text);
        var node = xmlDoc.SelectNodes("pdml/packet/proto[@name='ip']/@showname");
        foreach (XmlAttribute attribute1 in node)
        {
            string ip = attribute1.Value;
            var arr = ip.Split(); var src = arr[5]; var dst = arr[8];
            Dictionary<string, List<string>> dict = new Dictionary<string,List<string>>(StringComparer.OrdinalIgnoreCase);
            List<string> listDST;
            if (!dict.TryGetValue(src, out listDST))
            {
                dict[src] = l = new List<string>();
            }
            l.Add(listDST);
        }
        listBoxSRC.DataSource = new BindingSource(dict,null);
        listBoxSRC.DisplayMember = "Value";
        listBoxSRC.ValueMember = "Key";
    }
    private void listBoxSRC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxSRC.SelectedItem != null)
        {
            var keyValue = (KeyValuePair<string, List<String>>)listBoxSRC.SelectedItem;
            listBoxDST.DataSource = keyValue.Value;
        }
        else
        {
            listBoxDST.DataSource = null;
        }
    }
