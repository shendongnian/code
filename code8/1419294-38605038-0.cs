    List<int> useddays =new List<int>();
    foreach (Tuple<DateTime, DateTime> selected in selectedTimeSpans)
    {
        DateTime start = selected.Value1;
        DateTime end = selected.Value2;
        DateTime current = start;
        while(current <=end)
        {
            if(useddays.Contains((current-DateTime.MinValue).TotalDays)
                MessageBox. Show("Already used!");
            else
                 useddays.Add((current-DateTime.MinValue).TotalDays);
            current.AddDays(1);
        }
    }
