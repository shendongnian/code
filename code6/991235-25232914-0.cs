     class ObjectsToStore
     {
         ....
         public int? HashCodeOverwrite; 
     }
     class ComparerByHashCode : IEqualityComparer<ObjectsToStore>
     {
       public bool Equals(ObjectsToStore b1, ObjectsToStore b2)
       {
           if (b1.HashCodeOverwrite.HasValue || b2.HashCodeOverwrite.HasValue)
           {
               return b1.GetHashCode() == b2.GetHashCode());
           }
           // add all null checks here too.
           return b1.Equals(b2);
       }
       public int GetHashCode(ObjectsToStore b)
       {
         return b.HashCodeOverwrite.HasValue? b.HashCodeOverwrite.Value:b.GetHashCode();
       }
     }
