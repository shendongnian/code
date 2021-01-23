    public void SaveToFile(string filename)
    {
         File.WriteAllText(filename,"");
         using(StreamWriter strwriter = System.IO.File.AppendText(filename))
         {
             strwriter.Write(this.TextArea.Text);
         }
    }
