    public void AppendAllLinesAtNewLine(string path, IEnumerable<string> content)
    {
        // No file, just append as usual.
        if (!File.Exists(path))
        {
            File.AppendAllLines(path, content);
            return;
        }
            
        using (var stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite))
        using (var reader = new StreamReader(stream))
        using (var writer = new StreamWriter(stream))
        {
            // Determines if there is a new line at the end of the file. If not, one is appended.
            long readPosition = stream.Length == 0 ? 0 : -1;
            stream.Seek(readPosition, SeekOrigin.End);
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
