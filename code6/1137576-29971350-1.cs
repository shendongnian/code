    band.Summaries.Add("MySummary", 
                       SummaryType.Custom, 
                       new CountNonEmptyStringsCalculator(),           
                       band.Columns[columnItem.ColumnName],
                       SummaryPosition.Left,
                       null
                       );    
    
