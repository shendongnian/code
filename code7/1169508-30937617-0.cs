    string oldText = string.Empty;
    private void txtName_TextChanged(object sender, EventArgs e)
    {
        if (txtName.Text.All(chr => char.IsLetter(chr)))
        {
            oldText = txtName.Text;
            txtName.Text = oldText;
            txtName.BackColor = System.Drawing.Color.White;
            txtName.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            txtName.Text = oldText;
            txtName.BackColor = System.Drawing.Color.Red;
            txtName.ForeColor = System.Drawing.Color.White;
        }
        txtName.SelectionStart = txtName.Text.Length;
    }
