    lines = File.ReadAllLines(RecentFiles);
    List< ToolStripMenuItem > items = new List< ToolStripMenuItem >();
    using (StreamWriter writer = new StreamWriter(RecentFiles))
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (File.Exists(lines[i])) {
                writer.WriteLine(lines[i]);
                items.Add(new ToolStripMenuItem()
                  {
                    Text = lines[i]
                  });
            }
        }
    }
