                List<string> listBoxNames = new List<string>();
    
                foreach (Control control in tabPage1.Controls.AsQueryable())
                {
                    if (control.GetType() == typeof (ListBox))
                    {
                        listBoxNames.Add(control.Name);
                    }
                }
