    foreach(Control c in this.Controls)
    {
       if(c is CheckBox)
       {
           c.Checked = false;
       }
    }
