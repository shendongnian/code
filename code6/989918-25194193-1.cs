    public class Toyota { };
    public class Bmw { };
    public class Mercedes { };
    public class BrandFactory
    {
        public object GetBrand(string brandName)
        {
            return Activator.CreateInstance(null, brandName).Unwrap();
        }
    }
