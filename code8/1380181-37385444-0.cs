    foreach (Control control in groupBox1.Controls)
    {
        if (string.IsNullOrEmpty(control.Text) && string.IsNullOrEmpty(control.Text))
        {
            MessageBox.Show(control.Name + " Can not be empty");
        }
    }
