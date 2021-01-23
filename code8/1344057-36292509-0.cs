    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Border
    {
    	public Border()
    	{
    		InitializeAdornment();
    	}
    
    	public Border Clone() { return (Border)MemberwiseClone(); }
    
    	public bool Visible { get; set; }
    
    	private bool ShouldSerializeVisible() { return Visible != DefaultVisible; }
    	private void ResetVisible() { Visible = DefaultVisible; }
    
    	[Browsable(false)]
    	[RefreshProperties(RefreshProperties.All)]
    	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    	public bool DefaultVisible { get; set; }
    
    	private void InitializeAdornment()
    	{
    		Visible = DefaultVisible = true;
    		// Some initialization code here that don't do anything with the property...
    	}
    }
