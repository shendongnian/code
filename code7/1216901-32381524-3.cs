    var tempFile = Path.GetTempFileName();
    using (var file = File.OpenWrite(tempFile))
    using (var writer = new StreamWriter(file))
    {
        foreach (var line in File.ReadLines(filepath))
        {
            if (line.Contains("motd="))
            {
                writer.WriteLine("motd=" + textBox1.Text);
            }
            else
            {
                writer.WriteLine(line);
            }
        }
    }
    File.Delete(filepath);
    File.Move(tempFile, filepath);
