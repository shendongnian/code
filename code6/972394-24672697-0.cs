    public partial class ContentArticleHOAsubdivision
    {
        public int Id { get; set; }
    
        ...
    
        public virtual ICollection<SubdivisionHOA> SubdivisionsHOAs { get; set; }
    }
    
    public partial class SubdivisionHOA
    {
        public short Id { get; set; }
        
        ...
     
        public int ContentArticleHOAsubdivisionId { get; set; }
    
        [ForeignKey("ContentArticleHOAsubdivisionId")]
        public virtual ContentArticleHOAsubdivision ContentArticleHOAsubdivision { get; set; }
    }
