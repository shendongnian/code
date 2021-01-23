    using Infragistics.Shared;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    
    private class CountNonEmptyStringsCalculator : ICustomSummaryCalculator 
    {
    	private decimal total = 0;
    
    	public void BeginCustomSummary(SummarySettings summarySettings, RowsCollection rows )
    	{
    		total = 0;
    	}
    
    	public void AggregateCustomSummary(SummarySettings summarySettings, UltraGridRow row )
    	{    
    		object myString = row.GetCellValue(summarySettings.SourceColumn);    
    		if ((myString is DBNull) || String.IsNullOrEmpty(myString.ToString()))
    			return;
    	    total++;
    	}
        	
    	public object EndCustomSummary( SummarySettings summarySettings, RowsCollection rows )		
    	{
     		return total;    
    	}
    }
