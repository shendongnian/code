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
     
     //This method can be either static or not
     //Please note that i do not implement the ICloneable interface. There is discussion in the community it should be marked as obsolete because one can't tell if it's doing a shallow-copy or deep-copy
     public static Professor Clone(Professor original)
     {
       var clone = new Professor(original.id, original.firstName, original.lastName);
       return clone;
     }
    }
