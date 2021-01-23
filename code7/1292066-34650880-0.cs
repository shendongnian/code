     public class ParentClass<TChild>  where TChild : class
        {
            public List<TChild> ParentList { get; set; }
            public Guid ParentId { get; set; }
            public int ParentProperty { get; set; }
    
    
            public ParentClass()
            {
                ParentId = Guid.NewGuid();
                ParentList = new List<TChild>();
            }
        }
    
        public class ChildClass : ParentClass<ChildClass>
        {
            public string ChildProperty { get; set; }
    
        }
