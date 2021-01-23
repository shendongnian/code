        int days = 0;
        Datetime d;
        for (int i = 1; i < pastedCells -1; i++){ 
                d = Convert.ToDateTime(dgv_Copy.Rows[i].Cells[1].Value);
                days = DateTime.DaysInMonth(d.Year, d.Month);
                Console.WriteLine(days + "\t" + d);
           }
        //result:
        //31	2002-05-31 0:00
        //30	2002-11-30 0:00
        //31	2003-05-31 0:00
        //30	2003-06-30 0:00
        //31	2003-10-31 0:00
        //30	2003-11-30 0:00
        //29	2004-02-29 0:00
        //31	2004-10-31 0:00
