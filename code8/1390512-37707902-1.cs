    List<string> headerCols = new List<string>();
    for (int j = 0; j < columncount - 1; j++)
    {
        headerCols.Add(dgvSum.Columns[j].HeaderText);
    }
    builder.AppendLine(string.Join("\t", headerCols.ToArray()));
    for (int i = 0; i < rowcount - 1; i++)
    {
        ....
        ....
