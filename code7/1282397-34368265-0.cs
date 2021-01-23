    protected void chkListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                foreach (ListItem item in chkListBox.Items)
                {
                    if (item.Selected)
                    {
                        txtSelect.Text += item.Value;
                    }
                }
            }
