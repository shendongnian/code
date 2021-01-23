    public class Controller<T> : IDisposable where T : new()
    {
        public class RecordSet 
        {    
            private T Records;
        
            public RecordSet(T records)
            {
                Records = records;
            }        
            public void MoveNext()
            {
                // pass through to encapsulated instance
                Records.MoveNext();
            }            
        }
    }
