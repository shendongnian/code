    class BaseProduct
    {
        public string x;
    }
    
    class ChildProduct : BaseProduct
    {
        public string y;
    }
    
    class BaseFactory
    {
        string a;
        public virtual BaseProduct buildProduct(BaseProduct product = null)
        {
            if (product == null)
                product = new BaseProduct();
    
            product.x = a;
            return product;
        }
    }
    
    class ChildFactory : BaseFactory
    {
        string b;
        public override BaseProduct buildProduct(BaseProduct product = null)
        {
            if (product == null)
                product = new ChildProduct();
            ((ChildProduct)product).y = b;
            return base.buildProduct(product); //build BaseProduct.x
        }
    }
    
    ...
    var cFactory = new ChildFactory();
    var cProduct = c.buildProduct(); //create a ChildProduct with x=a, y=b
