    public class A {
        public A()
        { 
           BList=new List<B>();
        }
        public virtual ICollection<B> BList { get; set; }
    }
