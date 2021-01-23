    namespace MyProject.Entities
    {
        public enum ReasonOfVisit
        {
            NotSet = 0,
            For business reason = 1,
            For control = 2,
            For lefting package = 3,
            For leisure = 4
        }
    
        public class Visitor
        {
            ...
    
            public ReasonOfVisit ReasonOfVisit { get; set; }
    
            ...
        }
    }
