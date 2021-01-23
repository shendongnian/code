    private void openItem_Click(object sender, EventArgs e)
    {
        using (var openFileDialog1 = new OpenFileDialog())
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try {
                    string srtfilename = openFileDialog1.FileName;
                    string filetext = File.ReadAllText(srtfilename);
                    GetRichTextBox().Text = filetext;
    
                    tabControl1.SelectedTab.Text = Path.GetFileName(openFileDialog1.FileName);
    
                    GlobalPath = openFileDialog1.FileName;
                }
                catch (Exception ex) 
                {
                    // you may wish to log the entire exception including stack trace here
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
