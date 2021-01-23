    public class Visitor
    {
        ...
        public byte ReasonOfVisitAsByte { get; set; }
        public ReasonOfVisit ReasonOfVisit { get { return (ReasonOfVisit)ReasonOfVisitAsByte; }  
                                             set { ReasonOfVisitAsByte = (byte)value; } } 
        ...
    }
