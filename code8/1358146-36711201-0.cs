    string contents = File.ReadAllText(openFileDialog2.FileName);
    if (contents.Contains(function))
    {
        File.WriteAllText(openFileDialog2.FileName, contents.Replace(signal, replace));
        MessageBox.Show("Done");
    }
    
