    public class Controller<T> : IDisposable where T : new()
    {
        public class RecordSet 
        {    
            private T Records;
        
            public RecordSet(T records)
            {
                Records = records;
            }        
        }
    }
