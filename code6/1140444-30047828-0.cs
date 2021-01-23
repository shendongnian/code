    public interface IBaseBuilder
    {
        Product Build();
    }
    
    public interface IProductBuilder : IBaseBuilder
    {
        ICheckedInProductBuilder CheckIn();
    }
    
    public interface ICheckedInProductBuilder : IBaseBuilder
    {
        IDisposedProductBuilder Dispose();
    }
    
    public interface IDisposedProductBuilder : IBaseBuilder
    {
        
    }
