    List<string> lines = d.Split(new string[] { Environment.NewLine })
                          .ToList();
    // loop through all lines, but skip the first (lets assume it isn't tabbed)
    for (int i = 1; i < lines.Count; i++)
    {
        if (lines[i][0] == '\t') // current line starts with tab
        {
            lines[i - 1] += "\r\n" + lines[i]; // append it to prev line
            lines.RemoveAt(i); // remove current line from list
            i--; // and dec i so you don't skip an item
        }
    }
