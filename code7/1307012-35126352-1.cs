    public class Planet
    {
        public Planet()
        {
            Minerals = new HashSet<Mineral>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Planet_Name { get; set; }
        [Required]
        public int Planet_X { get; set; }
        [Required]
        public int Planet_Y { get; set; }
        [Required]
        public string Planet_Desc { get; set; }
        public virtual ICollection<Mineral> Minerals { get; set; }
    }
