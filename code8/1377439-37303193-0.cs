    public class Permissions
    { 
    
     public string Name;  // fields just for showing how to use them
     public int Rights;
     public override bool Equals(object obj)
       {
        var permission = obj as Permissions;
        if (permission != null) 
           {
              if(permission?.Name.Equals(this.Name) && permission.Rights.Equals(this.Rights)
              {
                 return true;
              }
           }
           return false
        }
        public override int GetHashCode()
        {
           return Name.GetHashCode() + 3*Rights.GetHashCode(); // you might use any alghorithm you see fit
        }
     }
