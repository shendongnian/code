    public partial class uporabnik
        {
            public uporabnik()
            {
                this.ocena = new HashSet<ocena>();
                this.predmet = new HashSet<predmet>();
                this.studentpredmet = new HashSet<studentpredmet>();
            }
    
            [Required]
            public int idUporabnik { get; set; }
    
            public Nullable<int> vpisnaStevilka { get; set; }
    
            [Required]
            [RegularExpression(@"^[A-z]*$"]
            public string ime { get; set; }
    
            [Required]
            [RegularExpression(@"^[A-z]*$"]
            public string priimek { get; set; }
    
            [RegularExpression(@"^[\w\d-\.]+@([\w\d-]+\.)+[\w-]{2,4}$"]
            public string email { get; set; }
    
            public string geslo { get; set; }
    
            [Required]
            public string mobi { get; set; }
    
            [Required]
            [RegularExpression(@"^[MZ]*$"]
            public string spol { get; set; }
    
            [RegularExpression(@"^[123]{1}$"]
            public Nullable<int> letnikStudija { get; set; }
    
            public System.DateTime datumRegistracije { get; set; }
    
            public System.DateTime zadnjiDostop { get; set; }
    
            public int idVloge { get; set; }
    
            [JsonIgnore]
            public virtual ICollection<ocena> ocena { get; set; }
    
            [JsonIgnore]
            public virtual ICollection<predmet> predmet { get; set; }
    
            [JsonIgnore]
            public virtual ICollection<studentpredmet> studentpredmet { get; set; }
    
            [JsonIgnore]
            public virtual vloga vloga { get; set; }
        }
