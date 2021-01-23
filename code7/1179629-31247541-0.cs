    public class ProductManager : IProductManager {
        //Constructor code here
        public IEnumerable<Product> ProductSearch(int? userId, DateTime? modifiedAfter, DateTime? modifiedBefore, Guid? productId)
        {
            using (var connection = _connection.OpenConnection())
            {
                const string sproc = "dbo.stp_Product_Search";
    
                return connection.Query<Product>(sproc, new
                {
                    User_ID = userId,
                    Modified_After = modifiedAfter,
                    Modified_Before = modifiedBefore,
                    Product_ID = productId
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
