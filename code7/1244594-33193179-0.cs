        private void button1_Click(object sender, EventArgs e)
        {
            this.ClearTextBoxes(this);
        }
        private void ClearTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }
