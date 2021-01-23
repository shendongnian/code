    static OpenFileDialog ofd = new OpenFileDialog();
    static SaveFileDialog sfd = new SaveFileDialog();
    static String cp;
    private void SaveClass()
    {
        sfd.DefaultExt = "txt";
        sfd.Filter = "Text Files | *.txt";
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            cp = sfd.FileName;
            var file = File.Create(cp);
            file.Close();
    
            File.WriteAllLines(@cp, StudentTextBox.Text.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
    
        }
     }
