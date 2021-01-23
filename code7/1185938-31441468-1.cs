        private void Form1_Load(object sender, EventArgs e)
        {            
            Settings s = Settings.Load();
            if (s == null) return;
            foreach (Control item in this.Controls)
            {
                item.ForeColor = s.ForeColors[item.Name];
                item.BackColor = s.BackColors[item.Name];
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings s = new Settings();
            foreach (Control item in this.Controls)
            {
                s.ForeColors.Add(item.Name, item.ForeColor);
                s.BackColors.Add(item.Name, item.BackColor);
            }
            s.Save();
        }
