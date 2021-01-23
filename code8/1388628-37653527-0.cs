    int line = txtProjects.GetLineFromCharIndex(txtProjects.SelectionStart) + 1; // zero based
    string[] lines = txtProjects.Lines;
    lines = lines.Take(line)
        .Concat(new[] {"\n"})
        .Concat(lines.Skip(line))
        .ToArray();
    txtProjects.Lines = lines;
