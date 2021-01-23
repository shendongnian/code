    private void btnGetSN_Click(object sender, EventArgs e)
    {
        // remove space from txtLongName
        var name = txtLongName.Text.Replace(" ", string.Empty);
        
        // take only the first 20characters from txtLongName
        txtShortName.Text = name.Substring(0, Math.Min(name.Length, 20));
    }
