    public BaseClass
    {
        //indeed, collection always will have zero or one items
        public virtual ICollection<Style> styles {get; set;}
        
        [NotMapped]
        public Style style {
           get { return styles.FirstOrDefault(); } 
           set { styles.Add(value); };
        }
    }
  
    public class Report : BaseClass
    {
        //other stuff...
    }
    
    public class ReportHeader : BaseClass
    {
        //other stuff...
    }
    
    public class Style
    {
        public int Id {get; set;}
    
        public virtual Report report {get; set;}
        [Index(IsUnique = true)]//to ensure that relation is exactly one-to-one
        public int? reportId {get; set;}
    
        public virtual ReportHeader reportHeader {get; set;}
        [Index(IsUnique = true)]//to ensure that relation is exactly one-to-one
        public int? reportHeaderId {get; set;}
    }
