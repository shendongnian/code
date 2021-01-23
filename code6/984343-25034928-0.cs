    foreach(Control c in this.Controls)
    {
       if(c is TextBox)
       {
           MessageBox.Show(c.Text);
       }
    }
