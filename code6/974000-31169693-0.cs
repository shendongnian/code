        public partial class ContentArticleHOAsubdivision
    {
        public int Id { get; set; }
        [ForeignKey("ContentArticleHOA")]
        public long ContentArticleId { get; set; }
       
        public virtual ContentArticleHOA ContentArticleHOA { get; set; }
        public virtual ICollection<SubdivisionHOA> SubdivisionsHOA { get; set; }
    }
    public partial class SubdivisionHOA
    {
        [Key, ForeignKey("TopTierDivisionHOA")]
        public short Id { get; set; }
        public string Name { get; set; }
    
         [ForeignKey("ContentArticleHOAsubdivision")]
        public short ContentArticleHOAsubdivision{ get; set; }
    
        public virtual TopTierDivisionHOA TopTierDivisionHOA { get; set; }
    }
