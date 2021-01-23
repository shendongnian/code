    public class Person {
        public Name{get;set;}
        // etc...
        public List<Relationship> Relationships{get;set;}
    }
    
    public class Relationship {
        public Person P1{get;set;}
        public Person P2{get;set;}
        public RelationshipKind Kind{get;set;}
    }
    
    public class RelationshipKind {
       // for example: Father
       public Name1 {get;set;}
       // for example: Child
       public Name2 {get;set;}
    }
