    public class Professor
    {
     public string id {get; set; }
     public string firstName{get; set;}
     public string lastName {get; set;}
    
     Professor(string ID, string firstName, string lastname)
      {
           this.id = ID;
           this.firstName = firstName;
           this.lastName = lastname;
      }
              
     public static Professor Clone(Professor original)
     {
       var clone = new Professor(this.id, this.firstName, this.lastName);
       return clone;
     }
}
