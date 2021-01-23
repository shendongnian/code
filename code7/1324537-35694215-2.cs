    say ddl1, ddl2, ddl3, ddl4, ddl5, ddl6 are ids of 6 dropdowns in your page.
    //if first dropdown have value selected the first will be read only and rest become editable
               if (ddl1.SelectedIndex > -1)
                {
                    ddl.Enabled = "false";
                }
                else
                {
                    ddl1.Enabled = "true";
                }
    
                if (ddl2.SelectedIndex > -1)
                {
                    ddl2.Enabled = "false";
                }
                else
                {
                    ddl2.Enabled = "true";
                }
    
                if (ddl3.SelectedIndex > -1)
                {
                    ddl3.Enabled = "false";
                }
                else
                {
                    ddl3.Enabled = "true";
                }
    
                if (ddl4.SelectedIndex > -1)
                {
                    ddl4.Enabled = "false";
                }
                else
                {
                    ddl4.Enabled = "true";
                }
    
                if (ddl5.SelectedIndex > -1)
                {
                    ddl5.Enabled = "false";
                }
                else
                {
                    ddl5.Enabled = "true";
                }
    
                if (ddl6.SelectedIndex > -1)
                {
                    ddl6.Enabled = "false";
                }
                else
                {
                    ddl6.Enabled = "true";
                }
    
