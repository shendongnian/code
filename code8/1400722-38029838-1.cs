    public class B
    {    
    	[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]     
        public virtual int Bid { get; set; }
    
        [Index("IX_B_Name_Aid", 1, IsUnique = true)]
        [Required]           
        Public virtual string BName {get ; set}
    
        [Index("IX_B_Name_Aid", 2, IsUnique = true)]
        [Required]      
        public virtual int Aid { get; set; }
    
        [ForeignKey("Aid")]
        public virtual  A A { get; set; }
    
        public virtual ICollection<C> C { get; set; }    
    }
    
    
    public class C
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]     
        public virtual int Cid { get; set; }
    
        [Key]
        [Column(Order = 0)]
        [Required]    
        Public virtual string CName {get ; set}    
    
        [Key]
        [Column(Order = 1)]
        [Required]          
        public virtual int Bid { get; set; }
    
        [ForeignKey("Bid")]
        public virtual  B B { get; set; } 
    }
