    private string OutputFile {get;set;}
    private void button1_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(this.OutputPath))
        {
            SaveFileDialog a1 = new SaveFileDialog();
            a1.FileName = textBox1.Text;
            a1.Filter = "Text Files(*txt)|*.txt";
            a1.DefaultExt = "txt";
            a1.InitialDirectory =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if(a1.ShowDialog() == DialogResult.OK)
            {
              this.OutputFile = ai.FileName
            }
        }
        this.SaveFile(this.OutputFile);
    }
    private void SaveFile(string FileName)
    {
        string newFile = FileName;
        string temp = newFile.Replace("YNATEST.", "");
        
        using(StreamWriter yazmaislemi = new StreamWriter(temp))
        {
            yazmaislemi.WriteLine(temp);
            yazmaislemi.Close();
        }
    }
