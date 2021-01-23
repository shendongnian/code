    public class Person{
        public int PersonId {get;set;}
        public string PersonName {get;set;}
        public Address PersonAddress{get;set;} 
       //You must have this field (PersonAddress) if you created model from
       // database having both the tables relations.
    }
