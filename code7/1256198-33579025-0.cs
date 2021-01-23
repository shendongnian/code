        private Dictionary<CheckBox, ListBox> lookup = new Dictionary<CheckBox, ListBox>();
        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox lb;
            CheckBox cb;
            for (int i = 1; i <= 30; i++)
            {
                lb = this.Controls.Find("listBox" + i.ToString(), true).FirstOrDefault() as ListBox;
                cb = this.Controls.Find("checkBox" + i.ToString(), true).FirstOrDefault() as CheckBox;
                if (lb != null && cb != null)
                {
                    lookup.Add(cb, lb);
                }
            }
        }
        private void checkBoxes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (lookup.ContainsKey(cb))
            {
                ListBox lb = lookup[cb];
                if (cb.Checked)
                {
                    if (lb.Items.Count >= 1)
                    {
                        tillgangligaForare.Items.Add(lb.Items[0]);
                        lb.Items.Clear();
                        uppdateraSummering();
                    }
                    lb.Enabled = false;
                    lb.Items.Add("FORDON EJ I BRUK");
                }
                else
                {
                    lb.Items.Clear();
                    lb.Enabled = true;
                }
            }            
        }
