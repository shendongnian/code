    private void Table1_ManualBuild(object sender, EventArgs e)
    {
      // get the data source by its name
      DataSourceBase columnData = Report.GetDataSource("Employees");
      // init the data source
      columnData.Init();
      
      // print the first table column - it is a header
      Table1.PrintColumn(0);
      // each PrintColumn call must be followed by either PrintRow or PrintRows call
      // to print cells on the column
      Table1.PrintRows();
      
      // now enumerate the data source and print the table body
      while (columnData.HasMoreRows)
      {
        // print the table body  
        Table1.PrintColumn(1);
        Table1.PrintRows();
        // go next data source row
        columnData.Next();
      }
      // print the last table column - it is a footer
      Table1.PrintColumn(2);
      Table1.PrintRows();
    }
