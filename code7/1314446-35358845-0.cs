    protected void btnProcess_click(object sender, EventArgs e)
            {
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        lblDisplay.Text += item.Text + ",";
                    }
                }
            }
