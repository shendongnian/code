    class FamilyMember{
        public string Name{get;set;}
        public string Rel{get;set;} 
    }
    class Person{
        public string Name{get;set;}
        public int Age{get;set;}
        public FamilyMember [] Family{get;set;}
    }
