      void check_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox sendercheck = sender as CheckBox;
            if (sendercheck.Checked)
            {
                foreach (var c in Container.Children)
                {
                    CheckBox check = c as CheckBox;
                    if (check != null)
                    {
                        if (check.Id != sendercheck.Id)
                        {
                            check.Checked = false;
                        }
                    }
                }
            }
        }
