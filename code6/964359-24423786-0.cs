    // add columns to your grid (could also be done in designer)
    dataGridView1.Columns.AddRange(
        new DataGridViewTextBoxColumn(),
        new DataGridViewTextBoxColumn(), 
        new DataGridViewTextBoxColumn());
    while (!process.StandardOutput.EndOfStream)
    {
        string[] values = process.StandardOutput.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        if (values.Length == 3) dataGridView1.Rows.Add(values);
    }
