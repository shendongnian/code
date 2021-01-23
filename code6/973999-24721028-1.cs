    public partial class ContentArticleHOAsubdivision
    {
    
        public short SubdivisionHOAId { get; set; }
        
        [ForeignKey("SubdivisionsHOAId")]    
        public virtual SubdivisionHOA SubdivisionHOA {get;set;}
    }
