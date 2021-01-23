    public partial class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid identity { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [ForeignKey("TestRefID")]  /* <--- */
        public TestRef Colour { get; set; }
    }
