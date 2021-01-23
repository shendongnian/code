         DataModel m = new DataModel();
        public Form1()
        {
           ...
            m.Servers.Subscribe(listBox1);
        }
     private void listBox2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                m.Servers[listBox1.SelectedIndex].Domains[listBox2.SelectedIndex].CSRs.Subscribe(listBox3);
            }
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                m.Servers[listBox1.SelectedIndex].Domains.Subscribe(listBox2);
            }
        }
