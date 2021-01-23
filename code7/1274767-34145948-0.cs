        public class SharedCollectionLayerSingleton
        {
          private static SharedCollectionLayerSingleton instance
          public static SharedCollectionLayerSingleton Instance
          {
            if(instance == null)
            {
             instance = new SharedCollectionLayerSingleton()
            }
            return instance;
          }
    
          private SharedCollectionLayerSingleton()
          {
           // initialize here
          }
        }
