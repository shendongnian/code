    private void groupBox1_Validating(object sender, CancelEventArgs e)
    {
        foreach (Control control in groupBox1.Controls)
        {
            if (!(control is TextBox || control is ComboBox))
                continue;
            if (!string.IsNullOrEmpty(control.Text))
                continue;
            MessageBox.Show(control.Name + " Can not be empty");
        }
    }
