    var path = @"d:\data\test.txt";
    var lines = File.ReadAllLines(path);
    var modifiedLines = lines.Select(line =>
    {
        if (line.StartsWith("Location=\""))
        {
            return string.Format("Location=\"{0}\"", textBox1.Text);
        }
        else
        {
            return line;
        }
    });
    File.WriteAllLines(path, modifiedLines);
