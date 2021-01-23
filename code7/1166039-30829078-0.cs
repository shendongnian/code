    private void Write(string file, RichTextBox box)
    {
        if (File.Exists(file))
        {
            System.IO.File.WriteAllLines(file, box.Lines);
        }
        else
        {
            MessageBox.Show("No file named " + file);
        }
    }
