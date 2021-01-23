        private void AddCols(DataTable dt, string Name)
    {
        char charac = 'A';
        for (int k = 1; k <= 3; k++)
        {
            for (int m = 1; m <= 4; m++)
            {
                dt.Columns.Add(columnPrefix + charac + m);
            }
    
            charac++;
        }
    }
     
