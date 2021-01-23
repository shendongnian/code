     Create Below Class and Deserialize it, but keep in mind this type of JSON not allowed in any language. See Data Objects it's in reapeated manners so none of object Deserialize it.
     public class Data
     {
      public double Data1 { get; set; }
      public double Data2 { get; set; }
      public double Data3 { get; set; }
     }
     public class Obj1
     {
       public double Value { get; set; }
       public Data Data { get; set; }
     }
    public class RootObject
    {
       public Obj1 Obj1 { get; set; }
    }
