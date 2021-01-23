    public class MyProduct
    {
        //some properties 
    }
    
    public MyProduct GetProductUsingId (int productID)
    {
        LiveService.Service live = new LiveService.Service();
        var product = live.GetProduct(2638975);
        var myProduct = new MyProduct();
        //Copy properties 
        myProduct.SomeProp = product.SomeProp;
        //etc
        return myProduct;
    }
