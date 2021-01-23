    public class Region
    {
        public Region()
        {
            this.Salesmen = new List<Salesman>();
        }
    
        [Key]
        public int Id { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        public int? SalesManagerId { get; set; }
    
        [ForeignKey("SalesManagerId")]
        public virtual Salesman SalesManager { get; set; }
        
        [InverseProperty("Region")]
        public virtual ICollection<Salesman> Salesmen { get; set; }
    
    }
