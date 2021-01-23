     private void button1_Click(object sender, EventArgs e)
        {
            LoadKeys();
            
        }
        Dictionary<string, List<string>> poi = new Dictionary<string, List<string>>();
        private void LoadKeys()
        {
            
           foreach (string line in File.ReadLines("TextFile1.txt"))
                    {
                        string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        poi.Add(parts[0], new List<string>());
                        poi[parts[0]] = new List<string>(parts.Skip(1));
                    }
            
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string txt = comboBox1.SelectedItem.ToString();
                if (poi.ContainsKey(txt))
                {
                    List<string> points = poi[txt];
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(points.ToArray());
                }
            }
        }
