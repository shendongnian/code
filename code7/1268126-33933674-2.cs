    IEnumerator<string> fileLines = File.ReadLines(path).GetEnumerator();
    while (fileLines.MoveNext())
    {
        string line = fileLines.Current;
        if (line.Contains(user))
        {
            while (fileLines.MoveNext())
            {
                line = fileLines.Current;
                if (line == " ")
                {
                    break;
                }
                listboxGroups.Items.Add(line);
            }
            break;
        }
    }
