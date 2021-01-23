    public static class DbValue
    {
        public const int FALSE = 0; //or something like this
    }
    public class MyEntity
    {
        
        [Column("Deprecated")]
        public integer DeprecatedStatus { get; set; }
        [NotMapped]
        public bool DeprecatedBool 
        { 
            get { this.DeprecatedStatus != 0 }
            set { this.DeprecatedStatus = (value ? 1 : 0) }
        }
    }
    //Then in Linq
    db.MyEntities.Where(e => e.DeprecatedStatus == DbValue.FALSE);
   
    //and
    db.MyEntities.Where(e => e.DeprecatedStatus != DbValue.FALSE);
