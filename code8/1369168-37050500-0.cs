    string strgrid1 = string.Empty;
    if (dttable2.Rows.Count > 0)
    { 
        /** Job security **/
        for(int i = 0; i < dttable2.Rows.Count - 1; i++)
        {
           if (dttable2.Rows[i]["Rating1"].ToString() == "Y")
           {
            strgrid1 = "Poor";
           }
           if (dttable2.Rows[i]["Rating2"].ToString() == "Y")
           {
            strgrid1 = "Satisfactory";
           }
           if (dttable2.Rows[i]["Rating3"].ToString() == "Y")
           {
            strgrid1 = "Good";
           }
           if (dttable2.Rows[i]["Rating4"].ToString() == "Y")
           {
            strgrid1 = "Excellent";
           }
        }
    }
