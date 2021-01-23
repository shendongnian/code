    class A {
        public IEnumerable<B> BList {get; set;}
    }
    
    class B {
        public IEnumerable<C> CList {get; set; }
        public int OrderId {get;set;}
    }
    
    class C {
        public int OrderId {get;set;}
    }
