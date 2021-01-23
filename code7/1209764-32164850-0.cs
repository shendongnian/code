    range = xlWorkSheet.UsedRange;
    int rowCount = range.Rows.Count;
     
    List<string> strArray = new List<string>();
    for (int i = 1; i < rowCount; i++)
    {
        if (myvalues.GetValue(i, 1) == null)
            strArray.Add(" ");   
        else  
           strArray.Add(myvalues.GetValue(i, 1).ToString());  
    }
