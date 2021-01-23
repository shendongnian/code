        string[] measurements = { "in", "ft", "mi", "cm", "m", "km" };
        
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string str in measurements)
            {
                cboFrom.Items.Add(str);
            }
            foreach (string str in measurements)
            {
                cboTo.Items.Add(str);
            }
        }
        private void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTo.SelectedItem == null)
            {
                cboTo.Items.Clear();
                foreach (string str in measurements)
                {
                    cboTo.Items.Add(str);
                }
                cboTo.Items.RemoveAt(cboFrom.SelectedIndex);
            }
            else
            {
                if (cboFrom.SelectedItem.ToString() == cboTo.SelectedItem.ToString())
                {
                    cboTo.Items.Clear();
                    foreach (string str in measurements)
                    {
                        cboTo.Items.Add(str);
                    }
                    cboTo.Items.RemoveAt(cboFrom.SelectedIndex);
                }
            }
        }
        private void cboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFrom.SelectedItem == null)
            {
                cboFrom.Items.Clear();
                foreach (string str in measurements)
                {
                    cboFrom.Items.Add(str);
                }
                cboFrom.Items.RemoveAt(cboTo.SelectedIndex);
            }
            else
            {
                if (cboTo.SelectedItem.ToString() == cboFrom.SelectedItem.ToString())
                {
                    cboFrom.Items.Clear();
                    foreach (string str in measurements)
                    {
                        cboFrom.Items.Add(str);
                    }
                    cboFrom.Items.RemoveAt(cboTo.SelectedIndex);
                }
            }
        }
