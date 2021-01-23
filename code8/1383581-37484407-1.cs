    public static class MapperExtension
    {
    public Customer_ Convert(this Customer customer)
    {
       return new Customer_()
       {
         FirstName = customer.FirstName,
         LastName = customer.LastName,
         Article = customer.Product.Convert()
       };
    }
    public static List<Article> Convert(this List<Product> products)
    {
        return products.Select(x=> new Article(){
        ArticleNumber = x.ProductNumber,
        ArticleColor = x.ProductColor
        };
    }
    }
