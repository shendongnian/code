    private void tb_TextChanged(object sender, TextChangedEventArgs args)
    {
        foreach (Control c in this.Controls)
        {
            if (c is TextBox)
            {
                if (string.IsNullOrEmpty(c.Text))
                {
                    this.okButton.Enabled = false;
                    return;
                }
            }
        }
        this.okButton.Enabled = true;
    }
