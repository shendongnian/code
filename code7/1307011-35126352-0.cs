    public class Mineral
    {
        public Mineral()
        {
            Planets = new HashSet<Planet>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public string Mineral_Desc { get; set; }
        [Required]
        public int rate { get; set; }
        [Required]
        public decimal ratio { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }        
    }
