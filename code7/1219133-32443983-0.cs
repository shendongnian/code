        FileStream fs1 = new FileStream(@"C:\myfile.txt", FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter writer = new StreamWriter(fs1);
        foreach (string line in yourlines)
        {
            WriteText(writer, line);
        }
        writer.Close();
        private void WriteText(StreamWriter writer, string text)
        {
            writer.Write(text + Environment.NewLine);
        }
