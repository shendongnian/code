    public void Form2(string fileName);
    {
        StreamReader sr = new StreamReader(fileName);
        this.RichTextBox1.Text = sr.ReadToEnd();
        this.Text = String.Format("NotePad -- {0}", fileName); //Title
        sr.Close();
    }
