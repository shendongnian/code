        // Creating a report
        IReport report = new ReportView();
        // Adding columns
        IColumn mycolumn = new ReportColumn();
        mycolumn.Values.Add(new IntValue() { Data = 1 });
        mycolumn.Values.Add(new DoubleValue() { Data = 2.7 });
        mycolumn.Values.Add(new IntValue("{0:#,##0;-#,##0;'---'}", 15));
        mycolumn.Values.Add(new DoubleValue("{0:0.#0;-0.#0;'---'}", 2.9));
        report.Columns.Add(mycolumn);
        // Looping through each column, and get each value in the formatted form
        foreach(var column in report.Columns)
        {
            foreach(var value in column.Values) { value.ToString(); }
        }
