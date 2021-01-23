    public interface IModel { 
      int Id { get; } 
    }
    
    public interface IModelRepository {
      void Save<T>(T model) where T : IModel;
      T Load<T>(int id) where T : IModel;
    }
