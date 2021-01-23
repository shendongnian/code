    public class AAA<TSOMECLASS>
    {
       public string PropertyA1 { get; set; }
       public TSOMECLASS PropertyA2 { get; set; }
    }
   
    public class BBB<TSOMECLASS>
    {
       public string PropertyB1 { get; set; }
       public AAA<TSOMECLASS> PropertyB2 { get; set; }
       public TSOMECLASS PropertyB3
       {
           get { return PropertyB2 == null ? null : PropertyB2.PropertyA1; }
           set 
           { 
               if (PropertyB2 == null) PropertyB2 = new AAA<TSOMECLASS>();
               PropertyB2.PropertyA1 = value; 
           }
       }
    }
