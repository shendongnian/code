    protected void chkIt_SelectedIndexChanged(object sender, EventArgs e)
        {
            var d=string.Empty;
            for (int i = 0; i < chkIt.Items.Count; i++)
                {
                    if (chkIt.Items[i].Selected == true)
                    {
                        d += chkIt.Items[i].Text;
                    }
                }
        }
