    public bool DeleteJETSRecords(DataTable JETSData)
    {
        int intCounter = 0;
        DataRow drTarget;
        // Parse all of the rows in the JETS Data that is to be deleted
        foreach (DataRow drCurrent in JETSData.Rows)
        {
            // Search the database data table for the current row's OutputID
            drTarget = cdtJETS.Rows.Find(drCurrent["OutputID"]);
            // If the row is found, then delete it and increment the counter
            if (drTarget != null)
            {
                drTarget.Delete();
                intCounter++;
            }
        }
        
        // Continue if all of the rows were found and removed
        if (JETSData.Rows.Count == intCounter && !cdtJETS.HasErrors)
        {
            // You have to call Update *before* AcceptChanges:
            ctaJETS.Update(dtJETS);
            cdtJETS.AcceptChanges();
            return true;
        }
        
        cdtJETS.RejectChanges();
        return false;
    }
