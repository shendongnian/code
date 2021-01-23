    int width = numbers.GetLength(0);
    int height = numbers.GetLength(1);
    for (int w = 0; w < width; w++)
    {
        dt.Columns.Add("Column" + (w + 1));
    }
    for (int h = 0; h < height; h++)
    {
        DataRow row = dt.NewRow();
        for (int w = 0; w < width; w++)
        {
            Console.Write("{0} ", numbers[w, h]);
            row["Column" + (w + 1)] = numbers[w, h];
        }
        dt.Rows.Add(row);
        Console.WriteLine();
    }
