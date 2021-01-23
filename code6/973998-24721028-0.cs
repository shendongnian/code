    public partial class ContentArticleHOAsubdivision
    {
    
        public short SubdivisionHOAId { get; set; }
        
        [ForeignKey("SubdivisionsHOAId")]    
        public SubdivisionHOA SubdivisionHOA {get;set;}
    }
