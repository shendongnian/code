     public class People {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //...
        public int CompanyId {get;set}
        public virtual Company Company{get;set;}
    }
