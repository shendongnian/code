    DataTable t; // assume this is table with "Category","Wee","Resolution" columns
    var pivotData = new PivotData(
        new string[] {"Category","Week"},
        new SumAggregatorFactory("Resolution"),
        new DataTableReader(t) );
    var pivotTable = new PivotTable(
        new []{"Week"}, // row dimension(s)
        new []{"Category"}, // column dimension(s)
        pivotData );
    // use pivotTable to access calculated values:
    var rowLabels = pivotTable.RowKeys;
    var colLabels = pivotTable.ColumKeys;
    var cellValue = pivotTable[0, 0].Value; // w1 x cat1 => 26
