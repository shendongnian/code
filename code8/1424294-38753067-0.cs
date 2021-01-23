    public IActionResult GetProducts(int? page, int? count)
            {
                var takePage = page ?? 1;
                var takeCount = count ?? DefaultPageRecordCount;
                       
                var calls = context.Products
    							.Skip((takePage - 1) * takeCount)
    							.Take(takeCount)
    							.ToList();
                    
                return Json(calls);
            }
