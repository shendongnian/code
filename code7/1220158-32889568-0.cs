    public class A
    {
       public A()
       {
           Cs = new List<C>(); 
           Ds = new List<D>(); 
       }
       //PK
       public int AId { get; set; }
    
       public ICollection<C> Cs { set; get; }
       public ICollection<D> Ds { set; get; }       
    } 
