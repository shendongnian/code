       public class Dog
        {
          public string Name {get;set}
          public string Breed {get;set}
          [JsonIgnore]
          public byte[] FileAboutDog {get;set}
        }
