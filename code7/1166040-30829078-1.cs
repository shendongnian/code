    private void Write(string file, RichTextBox box)
    {
        if (File.Exists(file))
        {
            StreamWriter sw = File.CreateText(file);
            for (int i = 0; i < box.Lines.Length; i++)
            {
                sw.WriteLine(box.Lines[i]);
            }
            sw.Flush();
            sw.Close();
        }
        else
        {
            MessageBox.Show("No file named " + file);
        }
    }
