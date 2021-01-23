    public class Repository<T>: Repository where T: Entity  // Your existing class
    {
      public override async Task<IEnumerable<Entity>> GetAllAsync()
      {
        //  Your existing implementation
      }
      //...existing stuff...
    }
