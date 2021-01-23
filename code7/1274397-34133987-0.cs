    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Save everything in a dialog box
        saveFileDialog1.ShowDialog();
        // Open the file and save the information
        Stream textOut = saveFileDialog1.OpenFile();
        list<string> textfile = texout.ReadLines();
        foreach(item i in itemlist)
        {
            texfile.Add(i);
        }
        StreamWriter writer = new StreamWriter(textOut);
        foreach(string str in texfile)
        {
            writer.WriteLine(str);
        }
        writer.Close();
    }
