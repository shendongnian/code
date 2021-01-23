    private void RowChanged(object sender, DataRowChangeEventArgs e)
    {
        // number of rows used 
        int Rows = dtSample.Rows.Count-1;
        if (e.Row == dtSample.Rows[Rows]) return;
    
        // display TotalSales / TotalUnits
        // get the units
        int TotUnits = dtSample
            .AsEnumerable()
            .Where(r => !r.IsNull("Quantity"))
            .Take(Rows)
            .Sum(n => n.Field<int>("Quantity"));
        
        // sum Sales, divide and display in DGV
        dtSample.Rows[Rows]["Price"] = dtSample
            .AsEnumerable()
            .Where(r => !r.IsNull("Sale"))
            .Take(Rows)
            .Sum(n => n.Field<decimal>("Sale")) / TotUnits;
    }
