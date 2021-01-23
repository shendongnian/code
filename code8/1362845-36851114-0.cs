    private void btnGetSN_Click(object sender, EventArgs e)
    {
        // remove space from txtLongName
        txtLongName.Text = txtLongName.Text.Replace(" ", string.Empty);
        
        // take only the first 20characters from txtLongName
        txtShortName.Text = txtLongName.Text.Substring(0, Math.Min(txtLongName.Text.Length, 20));
    }
