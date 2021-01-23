    foreach(Control c in this.Controls)
    {
       if(c is TextBox)
       {
           if (c.Name.Equals("TextBoxTotal")) // set the control name when you adding dynamic control 
                MessageBox.Show("Total value:" + c.Text);
       }
    }
