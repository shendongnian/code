    if (string.IsNullOrEmpty(txtP2.Text) || string.IsNullOrWhiteSpace(txtP2.Text)
       || string.IsNullOrEmpty(txtQ2.Text) || string.IsNullOrWhiteSpace(txtQ2.Text)
       || string.IsNullOrEmpty(txtR2.Text) || string.IsNullOrWhiteSpace(txtR2.Text))
    {
        MessageBox.Show("please complete the line 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtP2.Focus();
        txtA2.Text = "";
        return;
    }
