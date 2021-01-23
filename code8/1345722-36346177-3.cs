    const int Col1Width = 8;
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        string part1 = dt.Rows[i][0].ToString();
        string part2 = dt.Rows[i][1].ToString();
        listbox2.Items.Add(part1.PadRight(Col1Width , '\u00A0') + part2);
    }
