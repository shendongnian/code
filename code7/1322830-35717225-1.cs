    public class MyEntity {
       private MySubEntity SubEntity {get; set;}
       public string SubEntityValue 
       { 
         get 
         { 
             return SubEntity.Value;
         } 
         set 
         { 
             SubEntity.Value = value; 
         }
    }
