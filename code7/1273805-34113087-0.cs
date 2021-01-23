    public class Country : IEntity{
       public string Code { get; set; }
       ...
       public object GetKey(){
          return this.Code;
       }
       ...
    }
