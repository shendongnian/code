    public class Controller<T> : IDisposable where T : class, new()
    {
        protected Controller(String tablename, String keyname, String entitytype, String tableschema = "dbo")
        {
            ...
        }
       public class Recordset<TT> where TT : class, new()   
        {
            public TT myinheritedclass {get; set}
            public Int32 myprop {get; set;}
    
            public void MoveNext()
            {
                //do stuff
            }
        }
    
        public Recordset<T> myRecordset = new Recordset<T>()
    }
