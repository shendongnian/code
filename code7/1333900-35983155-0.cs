    for (int i = 0; i < dt.Rows.Count; i++)
    {
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            string a = dt.Rows[i][j].ToString() + "\t";
            Console.Write(a);
        }
        Console.Write("\n\r");
    }
