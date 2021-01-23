    public class MyEntity : IMySerializable
    {
      public int Id {get;set;}
      public string Name {get;set;}
      [NotMapped]
      public int Age {get;set;}
      [NotMapped]
      public string OtherData {get;set;}
      [NotMapped]
      public List<Blabla> BlaBlaList {get;set;}
      public byte[] SerializedData  
      {
        get
        {
          return this.MySerialize();
        } 
        set 
        {
          this.MyDeserialize(value);
        }
      }
    }
