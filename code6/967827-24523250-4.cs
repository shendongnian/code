    public class MyTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // optional
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // optional
        [Key]
        public String Name { get; set; }
    }
