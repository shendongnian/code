        private void ChangeStyleByTag(Control parent, string tag)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Tag!=null && c.Tag.Equals(tag))
                {
                    //FlatStyle = FlatStyle.Flat;
                    //FlatAppearance etc...;
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
