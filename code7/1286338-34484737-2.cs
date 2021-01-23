     public static class CommonExtensions
     {
         public static TValue TryGet<TObject, TValue>(this TObject obj, Func<TObject, TValue> getter, TValue defaultValue = default(TValue))
             where TObject : class
         {
             return obj == null ? defaultValue : getter(obj);
         }
         //If objects types are equals
         public static bool KeyEquals<TObject, TValue>(this TObject a, TObject b, Func<TObject, TValue> keyGetter)
            where TObject : class
         {
             return a != null 
                 && b != null 
                 && EqualityComparer<TValue>.Default.Equals(keyGetter(a), keyGetter(b));
         }
     }
      
          
     var isEqual = x.Id == y.Id
                   && x.UpdatedAt == y.UpdatedAt
                   && x.Name == y.Name                        
                   && x.RulesUrl == y.RulesUrl
                   //v1
                   && x.OngoingChallenges.TryGet(v => v.Count) == y.OngoingChallenges.TryGet(v => v.Count)
                   //v2
                   && x.MembershipIds.KeyEquals(y.MembershipIds, v => v.Count);
