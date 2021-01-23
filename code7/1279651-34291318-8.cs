    Form f;
    ComboBox cboCities;
    ComboBox cboPoi;
    Dictionary<string, List<string>> poi = new Dictionary<string, List<string>>();
    void Main()
    {
        f = new Form();
        cboCities = new ComboBox();
        cboCities.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCities.Items.AddRange(new string[] { "Berlin", "Munich", "Stuttgart"});
        cboCities.SelectedIndexChanged += cboCities_SelectedIndexChanged;
        f.Controls.Add(cboCities);
        cboPoi = new ComboBox();
        cboPoi.Location = new System.Drawing.Point(0, 30);
        f.Controls.Add(cboPoi);
        foreach (string line in File.ReadLines(@"D:\temp\poi.txt"))
        {
            string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            poi.Add(parts[0], new List<string>(parts.Skip(1)));
        }
        f.ShowDialog();
    }
    void cboCities_SelectedIndexChanged(object sender, EventArgs e)
    {
        string txt = cboCities.SelectedItem.ToString();
        if (poi.ContainsKey(txt))
        {
            List<string> points = poi[txt];
            cboPoi.Items.Clear();
            cboPoi.Text = string.Empty;
            cboPoi.Items.AddRange(points.ToArray());
        }
    }
