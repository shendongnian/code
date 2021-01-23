    dtSample = new DataTable();
    dtSample.Columns.Add(new DataColumn("Item", typeof(string)));
    dtSample.Columns.Add(new DataColumn("Quantity", typeof(int)));
    dtSample.Columns.Add(new DataColumn("Price", typeof(decimal)));
    dtSample.Columns.Add(new DataColumn("Sale", typeof(decimal)));
    
    // assign expression using the col names
    dtSample.Columns[3].Expression = "(Quantity * Price)";
