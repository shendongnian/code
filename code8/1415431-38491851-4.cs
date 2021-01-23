    public abstract class Updater<T> 
    {
         private readonly ILog _logger;
         public Name {get; private set;}
         public Updater(string name, ILog logger)
         {
             _logger= logger;
             Name = name;
         }
    
    
         protected abstract UpdateImpl(T updating);
    
         public Update(T updating)
         {
             _logger.Log("Started updater " + Name);
             try
             {
                 UpdateImpl(updating);
             }
             //DON'T DO THIS IN ACTUAL IMPLEMENTATION
             //DO NOT EAT ALL OF THE EXCEPTIONS
             catch ( Exception e)
             {
                _logger.Log(e);   
             }
             finally
             {
                 _logger.Log("Finished Updater " + Name);
             }
         }
    }
