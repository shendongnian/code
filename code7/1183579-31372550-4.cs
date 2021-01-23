    public abstract class LookupTableBase {
    	[Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.None)]
    	public int Id { get; set; }
    
    	[Required]
    	public string Name { get; set; }
    }
