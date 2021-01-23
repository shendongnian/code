    public class BrandFactory
    {
        public T GetBrand<T>() where T : CarModel
        { 
            return new T(); 
        }
    }
