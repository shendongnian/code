     public partial class CreativeOps
     {
        public CreativeOps()
        {
            CreativeNames = new HashSet<CreativeNames>();
        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Disabled { get; set; }
        public virtual ICollection<CreativeNames> CreativeNames { get; set; }
    }
    }
