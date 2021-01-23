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
             } while(Guids.Contains(_id));           
             Guids.Add(_id);
           }  
           protected UniqueObject(Guid guid)
           {
             if(Guids.Contains(guid))
               throw new ArgumentNullException("Object ID is not unique. Already being used by another object.");
             _id = guid;
           }
           // Make a better implementation of IDisposable
           public void Dispose()
           {
             guids.Remove(_id);
           }
        }
