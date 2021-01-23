    public void OpenFile(string fileName);
    {
        StreamReader sr = new StreamReader(fileName);
        this.RichTextBox1 = sr.ReadToEnd();
        sr.Close();
    }
