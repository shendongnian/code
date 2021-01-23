    say ddl1, ddl2, ddl3, ddl4, ddl5, ddl6 are ids of 6 dropdowns in your page.
            for (int count = 1; count <= 6; count++)
            {
                DropDownList ddl = new DropDownList();
                ddl.ID = "ddl" + count;
                if (ddl.SelectedIndex > -1)
                {
                    ddl.Enabled = false;
                }
                else
                {
                    ddl.Enabled = true;
                }
            }
