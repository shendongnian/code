    public ObservableCollection<DataSourceVM> Backends { get; set; }
    
    private void StartExport(String filepath)
    {
    	try
    	{
    		var dataSet = new DataSet();
    		var dataTable = new DataTable();
    		dataSet.Tables.Add(dataTable);
    		
    		// we assume that the properties of DataSourceVM are the columns of the table
    		// you can also provide the type via the second parameter
    		dataTable.Columns.Add("Property1");
    		dataTable.Columns.Add("Property2");
    		
    		foreach (var element in Backends)
    		{
    			var newRow = dataTable.NewRow();
    			
    			// fill the properties into the cells
    			newRow["Property1"] = element.Property1;
    			newRow["Property2"] = element.Property2;
    			
    			dataTable.Rows.Add(newRow);
    		}
    		
    		// Do excel export
    	}
    	catch (Exception e1)
      	{
        	MessageBox.Show("error");
      	}
    }
