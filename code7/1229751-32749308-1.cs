        public class ChangeChecker
         {
            private object Backup_Object_Value;
            private readonly object synchronizationToken = new object();
            private readonly ConcurrentStack<object> changes = new ConcurrentStack<object>();
        
            public bool HasChanges
            {
                get
                {
                    return changes.Count > 0;
                }
            }
        
            public ChangeChecker() { }
        
            public bool Changed(object obj)
            {
                bool result = false;
                lock (synchronizationToken)
                {
                  if (changes.TryPeek(out Backup_Object_Value) && !obj.Equals(Backup_Object_Value))
                    {
                      changes.Push(obj);
                      result = true;
                     }
                 }
                return result;
            }
    
            /// <summary>
            /// Returns all changes and clearout the history.
            /// </summary>
            /// <returns></returns>
            public IEnumerable<object> AcceptChanges()
            {
              lock (synchronizationToken)
               {
                  // keep the last updated of the object, if exists
                  if (!changes.TryPeek(out Backup_Object_Value))
                  {
                      yield break;
                  }
                }
                while (changes.Count > 0)
                {
                    object obj;
                    if (changes.TryPop(out obj))
                    {
                       yield return obj;
                    }
                }
            }
        }
