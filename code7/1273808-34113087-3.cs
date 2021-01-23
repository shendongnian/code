    public class Country : IEntity{
       public string Code { get; set; }
       ...
       object IEntity.GetKey(){
          return this.Code;
       }
       ...
    }
