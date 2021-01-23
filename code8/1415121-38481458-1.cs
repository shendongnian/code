    [Table("why")]
    public class why
    {
    	[Key]
    	[Column("primary_key_why")]
    	public int primary_key_why { get; set; }
    	[ForeignKey("what")]
    	[Column("some_column_why")]
    	public int some_column_why { get; set; }
    	public virtual what what { get; set; }
    }
