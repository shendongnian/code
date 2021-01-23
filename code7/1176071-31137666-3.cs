    protected void btnClear_Click(object sender, EventArgs e)
        {
            clearText(div_d);
        }
        private void clearText(Control PanelID)
        {
            foreach (Control c in PanelID.Controls)
            {
                if (c is TextBox)
                {
                    TextBox thetextBox = c as TextBox;
                    thetextBox.Text = "";
                }
            }
        }
