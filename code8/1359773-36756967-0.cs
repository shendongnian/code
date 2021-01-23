    public class Item
    {
     public string Name { get; set; }
     public int HoursLogged { get; set; }
     public string ToJsonString()
     {
      return "{" + "\"Name\":" + Name + ",HoursLogged:" + HoursLogged + "}";
     }
    }
