    var pivotData = new PivotData(
    	new string[] {"Date","Machine Num"},
    	new AverageAggregatorFactory("MU"),
    	new DataTableReader(t) );  // just a sample - you can use DB data reader
    var pivotTable = new PivotTable(
    	new []{"Date"}, // row dimension(s)
    	new [0], // column dimension(s)
    	pivotData );
    // use pivotTable.RowKeys and indexer for accessing pivot table values
