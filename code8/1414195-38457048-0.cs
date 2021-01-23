    public class KTextPanel : TableLayoutPanel
    {
        public KTextPanel()
        {
            ColumnCount = 1;
            RowCount = 1;
        }
    	
    	[DefaultValue(1)]
    	public new int ColumnCount
    	{
    		get
    		{
    			return base.ColumnCount;
    		}
    		set
    		{
    			base.ColumnCount = value;
    		}
    	}
    	
    	//... same for RowCount
    }
