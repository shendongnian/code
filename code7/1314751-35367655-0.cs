    namespace myApp.Helpers
    {
        public class MyHelper
        {
            private readonly DbContext context;
    
            public MyHelper(DbContext context)
            {
                this.context = context;
            }
    
            public async Task<ProductVM> GetProductAsync(int productId)
            {
                return await context.vwxProducts.Where(x => x.ProductId == productId).Select(x => new ProductVM { A = x.A, B = x.B }).FirstOrDefaultAsync();
            }
        }
    }
