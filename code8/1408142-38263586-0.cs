    public class Report
    {
        //indeed, collection always will have zero or one items
        public virtual ICollection<Style> styles {get; set;}
        //other stuff...
    }
    
    public class ReportHeader
    {
        //indeed, collection always will have zero or one items
        public virtual ICollection<Style> styles {get; set;}
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
