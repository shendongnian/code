    public class Sale
    {
         List<Product> Products;
         Client _SoldTheItemTo;
    
         public Sale(List<Product> products, Client client)
         {
            _SoldTheItemTo = client;
            Products = products;
         }
    }
