    while (reader.Read())
    {
       values = new object[reader.FieldCount];
       var cols = reader.GetValues(values);
       var item = String.Join("\t", values);
       items.Add(item);
    };
    data = String.Join("\n", items.ToArray());
    
    var tempDocument = application.Documents.Add();
    var range = tempDocument.Range();
    range.Text = data;
    var tempTable = range.ConvertToTable(Separator: Microsoft.Office.Interop.Word.WdTableFieldSeparator.wdSeparateByTabs,
                                        NumColumns: reader.FieldCount,
                                        NumRows: rows, DefaultTableBehavior: WdDefaultTableBehavior.wdWord9TableBehavior,
                                        AutoFitBehavior: WdAutoFitBehavior.wdAutoFitWindow);
