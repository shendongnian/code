    public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  
            var odabrano1 = glavniKodeks.Keys.ToList()[listBox1.SelectedIndex];
            glavniKodeks.TryGetValue(odabrano1, out kodeks);
            listBox2.DataSource = new BindingSource(kodeks.Keys, null);
        }
    
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = new List<Entry>();
            var odabrano2 = kodeks.Keys.ToList()[listBox2.SelectedIndex];
            kodeks.TryGetValue(odabrano2, out list);
        }
