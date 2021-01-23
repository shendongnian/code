    var lines = File.ReadAllLines(filepath);
    for (int i = 0; i < lines.Length; i++)
    {
        if(lines[i].Contains("motd="))
        {
            lines[i] = "motd=" + textBox1.Text;
        }
    }
    File.WriteAllLines(filepath, lines);
