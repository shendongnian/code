    public class BBB : AAA
    {
       public string PropertyB1 { get; set; }
       //inherit from AAA: public SOMECLASS from AAA) PropertyB3 
       // hide the other property from AAA
       private new string PropertyA1 { get; set; }
    }
