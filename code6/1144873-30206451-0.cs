        const long ROW_START = 2; 
  
        var sqlcmd = new SqlCommand(query, con);
        var sqlreader = sqlcmd.ExecuteReader();
    
        string c;
        double q;
        string curr_c = "~~~~~~~~~";
        double tot = 0;
        long r = 0;
        long rownum = ROW_START;
    
        while (sqlreader.Read())
        {
            q = (double)sqlreader["Quantity"];
            c = sqlreader["Category"].ToString();
            if (c != curr_c) 
            {
                if (rownum > ROW_START)
                {
                    ws.Cells[rownum, 1].Value = "Total";
                    ws.Cells[rownum, 2].Value = tot;
                    rownum += 1;
                }
                curr_c = c;
                tot = 0;
            }
            
            ws.Cells[rownum, 1].Value = c;
            ws.Cells[rownum, 2].Value = q;
            tot += q;
            rownum += 1;
        }
        ws.Cells[rownum, 1].Value = "Total";
        ws.Cells[rownum, 2].Value = tot;
