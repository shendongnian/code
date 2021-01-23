    public class Element
    {
    	public Element()
    	{
    		CauseElements = new List<Interaction>();
    		EffectElements = new List<Interaction>();
    	}
    
    	[Key]
    	public int ID { get; set; }
    
    	[Required, MaxLength(64)]
    	public string Name { get; set; }
    
    	#region Navigation
    
    	public virtual ICollection<Interaction> CauseElements { get; set; }
    	public virtual ICollection<Interaction> EffectElements { get; set; }
    
    	#endregion
    }
    
    public class Interaction
    {
    	[Key]
    	public int ID { get; set; }
    
    	[Index]
    	public int CauseID { get; set; }
    	
    	[Index]
    	public int EffectID { get; set; }
    
    	[MaxLength(64)]
    	public string Project { get; set; }
    
    	#region Navigation
    
    	[ForeignKey("CauseID")]
    	public virtual Element CauseElement { get; set; }
    
    	[ForeignKey("EffectID")]
    	public virtual Element EffectElement { get; set; }
    
    	#endregion
    }
