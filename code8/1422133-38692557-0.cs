                if (dllselection.SelectedValue == "")
                {
                    Code.Enabled = false;
                }
                else
                {
                    Code.Enabled = true;
                    filldropdown(dllselection.SelectedValue);  
                }
            }
