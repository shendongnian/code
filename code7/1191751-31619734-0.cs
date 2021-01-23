    public class A
    {
       public int Id{get;set;}
       //...
       public virtual ICollection<AB> ABs{get;set;}
    }
    public class B
    {
       public int Id{get;set;}
       //...
     public virtual ICollection<AB> ABs{get;set;}
    }
    public class AB
    {
       [Key,ForeignKey("A"),Column(Order=1)]
       public int AId{get;set;}
       [Key,ForeignKey("B"),Column(Order=2)]
       public int BId{get;set;}
       
       public virtual A A{get;set;}
       public virtual B B{get;set;}
       //Add here the extra column(s)
    }
