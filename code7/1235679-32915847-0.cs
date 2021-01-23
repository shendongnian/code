    private void btnBrowseBa_Click(object sender, EventArgs e)
    {
        string path = "";
        FolderBrowserDialog dlg = new FolderBrowserDialog();
        if(dlg.ShowDialog()== DialogResult.OK)
        {
            path = Path.Combine(dlg.SelectedPath, comboBox.Text);
        }
    }
