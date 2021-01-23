    public partial class Item3
    {
        public Item3()
        {
         Item1Name = string.empty;
         Item2Name = string.empty;
         Name = string.empty;
        }
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Item1Name { get; set; }
    
        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Item2Name{ get; set; }
    
        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Name { get; set; }
    }
