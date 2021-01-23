    DataTable inputTable; // your input data
    var pivotData = new PivotData(
    	new string[] {"Month","PCode"},
    	new SumAggregatorFactory("Sales"),
    	new DataTableReader(inputTable) );
