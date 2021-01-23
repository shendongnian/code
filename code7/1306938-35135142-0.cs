    public class A
    {
     [XmlElementAttribute("B", typeof(B))]
     [XmlElementAttribute("C", typeof(C))]
     [XmlElementAttribute("D", typeof(D))]
     public List<object> BCD {get; set;}
    }
   
    public class B
    {
     // class details
    }
    public class C
    {
     // class details
    }
    public class D
    {
     // class details
    }
