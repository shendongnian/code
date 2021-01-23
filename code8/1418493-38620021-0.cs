    // Select a range of data for the Pivot Table.
    pivotData = _xlSheet.get_Range("A1", "D25");
    
    // Select location of the Pivot Table.
    pivotDestination = _xlSheet.get_Range("A30", useDefault);
    
    // Add a Pivot Table to the Worksheet.
    _xlBook.PivotTableWizard(
        Excel.XlPivotTableSourceType.xlDatabase,
        pivotData,
        pivotDestination,
        pivotTableName3,
        true,
        true,
        true,
        true,
        useDefault,
        useDefault,
        false,
        false,
        Excel.XlOrder.xlDownThenOver,
        0,
        useDefault,
        useDefault
        );
    
    // Set variables for used to manipulate the Pivot Table.
    pivotTable =
        (Excel.PivotTable)_xlSheet.PivotTables(pivotTableName3);
    titlePivotField = ((Excel.PivotField)pivotTable.PivotFields(1));
    authorPivotField = ((Excel.PivotField)pivotTable.PivotFields(2));
    pubyearPivotField = ((Excel.PivotField)pivotTable.PivotFields(3));
    statusPivotField = ((Excel.PivotField)pivotTable.PivotFields(4));
    
    // Format the Pivot Table.
    pivotTable.Format(Excel.XlPivotFormatType.xlReport2);
    pivotTable.InGridDropZones = false;
    
    // Set Page Field
    authorPivotField.Orientation =
        Excel.XlPivotFieldOrientation.xlPageField;
    
    // Set Row Field[s]
    titlePivotField.Orientation =
        Excel.XlPivotFieldOrientation.xlRowField;
    pubyearPivotField.Orientation =
        Excel.XlPivotFieldOrientation.xlRowField;
    statusPivotField.Orientation =
        Excel.XlPivotFieldOrientation.xlHidden;
    
    authorPivotField.CurrentPage = "(All)";
    
    _xlSheet.Columns.AutoFit();
