    protected void chklstOptions_SelectedIndexChanged(object sender, EventArgs e)
            {
                foreach (ListItem lt in chklstOptions.Items)
                {
                    if (lt.Value == "RepOptionB")
                        if (lt.Selected)
                        {
                            foreach (ListItem lm in chklstOptions.Items)
                            {
                                if (lm.Value == "RepOptionA")
                                    lm.Selected = false;
                            }
                        }
                }
                foreach (ListItem lt in chklstOptions.Items)
                {
                    if (lt.Value == "RepOptionA")
                        if (lt.Selected)
                        {
    
                            foreach (ListItem lm in chklstOptions.Items)
                            {
                                if (lm.Value == "RepOptionB")
                                    lm.Selected = false;
                            }
                        }
                }
            }
