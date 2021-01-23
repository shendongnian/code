    summaryTable = runsQuery.Clone(); // copy schema.
    foreach (DataRow row in overRuns)
    {
         summaryTable.ImportRow(row);  
    }
