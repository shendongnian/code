    // group and calculate measures
    var pivotData = new PivotData(
    	new string[] {"col1","col2"},
    	new SumAggregatorFactory("val1"),
    	new DataTableReader(t) );
    // get pivot table model for accessing columns/rows/values in easy way
    var pivotTable = new PivotTable(
    	new []{"col2"}, // row dimension(s)
    	new []{"col1"}, // column dimension(s)
    	pivotData );
    
    var rowLabels = pivotTable.RowKeys;
    var colLabels = pivotTable.ColumKeys;
    var cellValue = pivotTable[0, 0].Value; // R1 + C1: 4
    var grandTotal = pivotTable[null,null].Value; // 10
