    public void OpenFile(string fileName);
    {
        StreamReader sr = new StreamReader(fileName);
        this.RichTextBox1.Text = sr.ReadToEnd();
        sr.Close();
        this.Text = String.Format("NotePad -- {0}", fileName); //Title
    }
