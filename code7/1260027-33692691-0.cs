    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }
        public bool Deleted { get; set; }
    }
    
    public class Update : BaseModel
    {
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public override int Id { get { return base.Id; } set { base.Id = value; } }
        public DateTime Updated { get; set; }
    }
