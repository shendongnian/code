    public class Foo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
    
        [Key, Column(Order = 1)]
        public string Name{ get; set; }
    }
