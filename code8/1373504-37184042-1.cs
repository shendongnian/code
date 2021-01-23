    protected void check1_SelectedIndexChanged(object sender, EventArgs e)
            {
                mess.Text = "Selected Item(s):";
                for (int i = 0; i < check1.Items.Count; i++)
                {
                    if (check1.Items[i].Selected == true)
                    {
                        mess.Text += check1.Items[i].Text;
                    }
                }
            }
