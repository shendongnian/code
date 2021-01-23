    // Clone() only clones the table structure. It does not also clone the data.
    DataTable dtFinal = dtOriginal.Clone();
    for (int i = 0; i < dtOriginal.Rows.Count; i++)
    {
        bool isDupe = false;
        for (int j = 0; j < dtFinal.Rows.Count; j++)
        {
            if (dtOriginal.Rows[i][0].ToString() == dtFinal.Rows[j][0].ToString()
                && dtOriginal.Rows[i][1].ToString() == dtFinal.Rows[j][1].ToString()
                && dtOriginal.Rows[i][2].ToString() == dtFinal.Rows[j][2].ToString())
            {
                dtFinal.Rows[j][3] = int.Parse(dtFinal.Rows[j][3].ToString()) + int.Parse(dtOriginal.Rows[i][3].ToString()); 
                isDupe = true;
                break;
            }
        }
        if (!isDupe)
        {
            dtFinal.ImportRow(dtOriginal.Rows[i]);
        }
    }
