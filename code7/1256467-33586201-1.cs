    public string SkinURL { get; set;}
    private void btnDone_Click(object sender, EventArgs e)
    {
        if (txtSkinURL.Text == @"Skin URL")
        {
            MessageBox.Show(@"Please enter a URL...");
        }
        else
        {
            SkinURL = txtSkinURL.Text;
            Close();
        }
    }
