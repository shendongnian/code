    using System.Runtime.Serialization;
    
    [DataContract]
    public class Person()
    {
    
     [DataMember]
     public string Age{get; set;}
    
     [DataMember]
     public string Path{get; set;}
    
     public Person(string age, string path)
     {
      this.Age = age;
      this.Path = path;
     }
    }
