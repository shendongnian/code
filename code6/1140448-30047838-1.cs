    public class ProductBuilder : IInUseProductBuilder, IDisposedProductBuilder
    {
        public IDisposedProductBuiler Dispose()
        {
            product.Status = product.DISPOSED; 
            return this;
        }
    }
