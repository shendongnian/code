        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (sender as CheckBox);
            if (cb.Checked == true)
            {
                cb.Text = "B";
                cb.BackColor = Color.Green;
            }
            else
            {
                cb.Text = "1";
                cb.BackColor = BackColor;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType()== typeof(CheckBox))
                {
                    (item as CheckBox).CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
                }
                
            }
        }
