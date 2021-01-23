    public void SaveToFile(string filename)
    {
    File.WriteAllText(filename,"");
    StreamWriter strwriter = System.IO.File.AppendText(filename);
    strwriter.Write(this.TextArea.Text);
    strwriter.Close();
    strwriter.Dispose();
    }
