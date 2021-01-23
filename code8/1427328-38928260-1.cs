    private void RowChanged(object sender, DataRowChangeEventArgs e)
    {
        // lastrow is used a lot
        int lastRow = dtSample.Rows.Count-1;
        if (e.Row == dtSample.Rows[lastRow]) return;
    
        // display TotalSales / TotalUnits
        // get the units
        int TotUnits = dtSample
            .AsEnumerable()
            .Where(r => !r.IsNull("Quantity"))
            .Take(lastRow)
            .Sum(n => n.Field<int>("Quantity"));
        
        // sum Sales and divide
        dtSample.Rows[lastRow]["Price"] = dtSample
            .AsEnumerable()
            .Where(r => !r.IsNull("Sale"))
            .Take(lastRow)
            .Sum(n => n.Field<decimal>("Sale")) / TotUnits;
    }
