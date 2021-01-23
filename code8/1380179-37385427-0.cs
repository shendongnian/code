    private void groupBox1_Validating(object sender, CancelEventArgs e)
    {
        foreach (Control control in groupBox1.Controls)
        {
            if (control is ComboBox)
            {
                ComboBox combo = (ComboBox)control;
                if (string.IsNullOrEmpty(combo.Text)) MessageBox.Show(combo.Name + " Can not be empty");
            }
            else if (control is TextBox)
            {
                TextBox txtBox = (TextBox)control;
                if (string.IsNullOrEmpty(txtBox.Text)) MessageBox.Show(txtBox.Name + " Can not be empty");
            }
        }
    }
