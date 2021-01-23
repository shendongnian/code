    string a = "";
    
    for (int i = 0; i < dt.Rows.Count; i++)
            {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                a += dt.Rows[i][j].ToString() + "\t";
            }
             a += "\n";
        }
    Console.Writeline(a);
