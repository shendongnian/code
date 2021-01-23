            public IHttpActionResult Get(int id)
        {
            try
            {
                Product product;
                var productRepository = new ProductRepository();
                if (id > 0)
                {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = productRepository.Create();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
