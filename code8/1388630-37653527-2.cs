    int lineCount = txtProjects.GetLineFromCharIndex(txtProjects.SelectionStart) + 1; // zero based
    string[] lines = txtProjects.Lines;
    txtProjects.Lines = lines 
        .Take(lineCount)
        .Concat(new[] {"\n"})
        .Concat(lines.Skip(lineCount))
        .ToArray();
