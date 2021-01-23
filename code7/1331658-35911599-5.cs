    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.FileName))
        {
            // call SaveAs 
            saveAsToolStripMenuItem_Click(sender, e);
        } else {
            // we already have the filename. we overwrite that file.
            StreamWriter writer = new StreamWriter(this.FileName);
            writer.Write(richTextBox1.Text);
            writer.Close();
        }
    }
