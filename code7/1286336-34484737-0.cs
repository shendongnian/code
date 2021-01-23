     public static class CommonExtensions
     {
         public static TValue TryGet<TObject, TValue>(this TObject obj, Func<TObject, TValue> getter, TValue defaultValue = default(TValue))
             where TObject : class
         {
             return obj == null ? defaultValue : getter(obj);
         }
     }
            
     var isEqual = x.Id == y.Id
                   && x.UpdatedAt == y.UpdatedAt
                   && x.Name == y.Name                        
                   && x.RulesUrl == y.RulesUrl
                   && x.OngoingChallenges.TryGet(v => v.Count) == y.OngoingChallenges.TryGet(v => v.Count)
                   && x.MembershipIds.TryGet(v => v.Count) == y.MembershipIds.TryGet(v => v.Count);
