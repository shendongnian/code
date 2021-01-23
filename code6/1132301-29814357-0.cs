     public class A
    {
        public int Id { get; set; }
        public virtual B Bobject { get; set; }
        public int BId;
        public virtual ICollection<C> Cs { get; set; }
    }
     public class B
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<A> As { get; set; }
        }
    }
     public class C
        {
            public int Id { get; set; }
            public string TransactionId { get; set; }
            public virtual A Aobj { get; set; }
            public int AId { get; set; }
        }
