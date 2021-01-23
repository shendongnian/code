    private string PadCenter(string source, int length, char space)
    {
        int spaces = length - source.Length;
        int padLeft = spaces / 2 + source.Length;
        return source.PadLeft(padLeft, space).PadRight(length, space);
    }
    ...
    const int Col1Width = 12;
    const int Col2Width = 8;
    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        string part1 = dt.Rows[i][0].ToString();
        string part2 = dt.Rows[i][1].ToString();
        listbox2.Items.Add(PadCenter(part1, Col1Width, '\u00A0') + PadCenter(part2, Col2Width, '\u00A0'));
    }
