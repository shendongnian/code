    public partial class ResultClass
        {
         public string Name {get;set;}
         public int OrderId {get;set;}
         public double TotalPrice {get;set;}
        }
    
    public List<ResultClass>  GetProductSalesInfoById(int id)
     {
         var query = from product in database.Products
             join sales in database.SalesOrderDetails
                 on product.ProductID equals sales.ProductID
             select new ResultClass {Name = product.Name,OrderId = sales.SalesOrderID,TotalPrice = (sales.UnitPriceDiscount)*sales.OrderQty*sales.UnitPrice};
    
         
         return result.ToList();
     } 
