    [Table("what")]
    public class what
    {
    	[Key]
    	[Column("primary_key_what")]
    	public int primary_key_what { get; set; }
    	[Column("another_column_what")]
    	public int another_column_what { get; set; }
    	public virtual ICollection<why> whys { get; set; }
    }
