       public class A
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    
    
        public class B : A, IAmB
        {            
            public B(long id,string name)
            {
    
            }
        }
    
        public interface IAmB{}
