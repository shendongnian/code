    public interface IInUseProductBuilder
    {
        IDisposedProductBuilder Dispose();
    }
    
    public interface IDisposedProductBuilder
    {
        IBuiltProductBuilder Build();
    }
