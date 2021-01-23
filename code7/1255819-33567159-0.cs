    class Parent
    {
        public Parent A { get; set; }
        public Parent B { get; set; }
    
        Parent(Parent a, Parent b)
        {
            A = a;
            B = b;
        }
    }
