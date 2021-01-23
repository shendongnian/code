        private void ChangeStyleByTag(Control parent, string tag)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Tag!=null && c.Tag.Equals(tag))
                {
                    (c as Button).FlatStyle = FlatStyle.Flat;
                    (c as Button).FlatAppearance.BorderSize = 3;
                    (c as Button).FlatAppearance.BorderColor = Color.Blue;
                }
                else
                    ChangeStyleByTag(c, tag);
            }
        }
        private void buttonBritishGas_Click(object sender, EventArgs e)
        {
            
            ChangeStyleByTag(this, "SelectedSupplier");
            ChangeStyleByTag(this, "Supplier");
        }
