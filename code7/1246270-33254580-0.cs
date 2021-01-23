    class A {
        public int Id {get; set;}
        public string Name {get; set;}
        public int CFieldId {get; set;}
        public virtual C CField {get; set;}
    }
    
    class B {
        public int Id {get; set;}
        public string Name {get; set;}
        public DateTime Date {get; set;}
        public int CFieldId {get; set;}
        public virtual C CField {get; set;}
    }
    
    class C {
        public int Id {get; set;}
        public string Name {get; set;}
    }
    
    class D {
        public int Id {get; set;}
        public string Title {get; set;}
        public int AFieldId {get; set;}
        public int BFieldId {get; set;}
        public virtual A AField {get; set;}
        public virtual B BField {get; set;}
    }
