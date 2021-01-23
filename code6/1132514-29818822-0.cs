    public class RootObject{
      public List<DataObject> data{ get; set;}
    }
    public class DataObject {
       public int id { get; set;}
       public string value { get; set; }
       public List<DataObject> childObject{ get; set;}
    }
