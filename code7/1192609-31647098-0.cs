    protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForms(pnl);
        }
        public void ClearForms(Control c)
        {
            foreach (var item in c.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
                if (item is ListItem)
                {
                    ((ListItem)item).Text = "Choose...";
                    ((ListItem)item).Value = "-1";
                }
            }
        }
