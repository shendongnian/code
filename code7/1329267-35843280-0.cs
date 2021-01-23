        abstract class UniqueObject : IDisposable
        {
           static protected HashSet<Guid> Guids = new HashSet<Guid>();
           Guid _id;
        
           public Guid ObjectID { get { return _id; } }
        
           protected UniqueObject()
           {
             do
             {
               _id = Guid.NewGuid();
             } while(Guids.Contains(id));           
             guids.Add(_id);
           }  
           // Make a better implementation of IDisposable
           public void Dispose()
           {
             guids.Remove(_id);
           }
        }
