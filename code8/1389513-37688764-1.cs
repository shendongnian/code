    public class Blog
    {
    	[Key]
    	public int Id { get; set; }
    	
    	[Required]
    	// etc
    	public string Titel { get; set; }
        
    	public string Beschrijving { get; set; }
                  
        public bool Content { get; set; }
                   
    	public bool Verwijderd { get; set; }
        
    	[ForeignKey("Auteur")]
    	public string AuteurId { get; set; }
    	
    	public virtual ApplicationUser Auteur { get; set; }
    }
