    StreamWriter writer = new StreamWriter("c:\\test.txt", true);
    foreach (string l in richTextBox1.Lines)
    {
        writer.WriteLine(l);
    }
    writer.Flush();
    writer.Close();
