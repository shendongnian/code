    public class ContentArticleHOAsubdivision
    {
         ...Coment this
         //public short SubdivisionHOAId { get; set; }
         ...
         [InverseProperty(" create property for ContentArticleHOAsubdivision on SubdivisionHOA")]
         public virtual ICollection<SubdivisionHOA> SubdivisionsHOA { get; set; }
    }
