    public class Entity {
       //assuming you want the default behavior to be "serialize all properties"
       public Entity() {
           ShouldSerializeProperty1 = true;
           ShouldSerializeProperty2 = true;
           ShouldSerializeProperty3 = true;
       }
       public string Property1 {get;set;}
       public bool ShouldSerializeProperty1 {get;set;}
       
       public string Property2 {get;set;}
       public bool ShouldSerializeProperty2 {get;set;}
       public int Property3 {get;set;}
       public bool ShouldSerializeProperty3 {get;set;}
    }
