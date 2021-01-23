    public class User : IMappedEntity 
    {
        [Key]
        [Column("USER_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        ...
    }
