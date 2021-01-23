    cl.val += "11";
    foreach (Control c in this.Controls)
    {
           if (c is TextBox)
           {
                c.DataBindings.Clear();
                c.DataBindings.Add("Text", cl, "val", false, DataSourceUpdateMode.OnPropertyChanged);
            }
     }
