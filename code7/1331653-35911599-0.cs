    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog open = new OpenFileDialog();
        open.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
        open.Title = "Open File";
        open.FileName = "";
        if (open.ShowDialog() == DialogResult.OK)
        {
            // save the opened FileName in our variable
            this.FileName = open.FileName;
            this.Text = string.Format("{0}", Path.GetFileNameWithoutExtension(open.FileName));
            StreamReader reader = new StreamReader(open.FileName);
            richTextBox1.Text = reader.ReadToEnd();
            reader.Close();
        }
    }
