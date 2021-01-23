    string[] fileLines = File.ReadAllLines(path);
    for (int lineIndex = 0; lineIndex < fileLines.Length; lineIndex++)
    {
        string line = fileLines[lineIndex];
        if (line.Contains(user))
        {
            while(++lineIndex < fileLines.Length && (line = fileLines[lineIndex]) != " ")
            {
                listboxGroups.Items.Add(line);
            }
            break;
        }
    }
