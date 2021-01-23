    public class Text
    {
    	[Key]
    	[Column(Order = 1)]
    	[Required]
    	[MinLength(7)]
    	[MaxLength(7)]
    	public string Fieldname { get; set; }
    
    	[Key]
    	[Column(Order = 2)]
    	[Required]
    	[MaxLength(2), MinLength(2)]
    	public string LanguageCode { get; set; }
    
    	[ForeignKey("LanguageCode")]
    	public virtual Language Language { get; set; }
    
    	[MaxLength(50)]
    	[MinLength(1)]
    	[Required]
    	public string Description { get; set; }
    }
