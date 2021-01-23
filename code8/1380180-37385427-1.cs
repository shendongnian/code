    private void groupBox1_Validating(object sender, CancelEventArgs e)
    {
        foreach (dynamic control in groupBox1.Controls)
        {               
            if (string.IsNullOrEmpty(control.Text)) MessageBox.Show(control.Name + " Can not be empty");              
        }
    }
