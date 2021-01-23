    public void AppendAllLinesToNewLine(string path, IEnumerable<string> content)
    {
        // No file, just append as usual.
        if (!File.Exists(path))
        {
            File.AppendAllLines(path, content);
            return;
        }
            
        using (var s = File.Open(path, FileMode.Open, FileAccess.ReadWrite))
        using (var reader = new StreamReader(s))
        using (var writer = new StreamWriter(s))
        {
            // Determines if there is a new line at the end of the file. If not, one is appended.
            long readPosition = s.Length == 0 ? 0 : -1;
            s.Seek(readPosition, SeekOrigin.End);
            string end = reader.ReadToEnd();
            if (end.Length != 0 && !end.Equals("\n", StringComparison.Ordinal))
            {
               writer.Write(Environment.NewLine);
            }
            // Simple write all lines.
            foreach (var line in content)
            {
                writer.WriteLine(line);
            }
        }
    }
