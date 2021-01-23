    public class Account : Entity
    {
        public int Id {get; set;}
        [Column("CreatedOn")]
        public PersianDate CreatedOn {get; set;}
    }
