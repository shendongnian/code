    class Repository<T>: Repository where T: Entity  // Your existing class
    {
      public async Task<IEnumerable<Entity>> GetAllAsync()
      {
        //  Your existing implementation
      }
      //...existing stuff...
    }
