    [Serializable]
    public class TableA : IBqlTable
    {
    	#region Id
    
    	[PXDBInt(IsKey = true)]
    	[PXUIField(DisplayName = "Id")]
    	public int? Id { get; set; }
    
    	public class id : IBqlField { }
    
    	#endregion
    
    
    	#region Description
    
    	[PXDBString(60, IsUnicode = true, InputMask = "")]
    	[PXUIField(DisplayName = "Description", Visibility = PXUIVisibility.SelectorVisible)]
    	public string Description { get; set; }
    
    	public class description : IBqlField { }
    
    	#endregion
    
    
    	#region InfoA
    
    	[PXDBString(60, IsUnicode = true, InputMask = "")]
    	[PXUIField(DisplayName = "Info A", Visibility = PXUIVisibility.SelectorVisible)]
    	public string InfoA { get; set; }
    
    	public class infoA : IBqlField { }
    
    	#endregion
    }
