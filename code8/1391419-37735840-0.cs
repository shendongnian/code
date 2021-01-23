    public class BBB
    {
       public string PropertyB1 { get; set; }
       public AAA PropertyB2 { get; set; }
       public PropertyB3
       {
         get
         {
           return PropertyB2.PropertyA2
         }
       }
    }
