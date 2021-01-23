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
    private void Table1_ManualBuild(object sender, EventArgs e)
    {
      // get the master data source
      DataSourceBase masterData = Report.GetDataSource("Categories");
      // get the detail data source
      DataSourceBase detailData = Report.GetDataSource("Products");
      
      // init the master data source
      masterData.Init();
      
      while (masterData.HasMoreRows)
      {
        // print first 3 rows that contains data from master data source
        Table1.PrintRow(0);
        Table1.PrintColumns();
        Table1.PrintRow(1);
        Table1.PrintColumns();
        Table1.PrintRow(2);
        Table1.PrintColumns();
        // init the detail data source. Pass masterData to allow master-detail relation
        detailData.Init(masterData);
        // print detail header
        Table1.PrintRow(3);
        Table1.PrintColumns();
        
        // print detail rows
        while (detailData.HasMoreRows)
        {
          // print the detail row
          Table1.PrintRow(4);
          Table1.PrintColumns();
        
          // go next data source row
          detailData.Next();
        }
        // print the detail footer row
        Table1.PrintRow(5);
        Table1.PrintColumns();
        Table1.PrintRow(6);
        Table1.PrintColumns();
        
        // go next data source row
        masterData.Next();
      }
