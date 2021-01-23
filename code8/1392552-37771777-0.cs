        public Task<EntitiesChangedResponse<Product>> UpdateProducts(List<Product> products)
        {
            var tcs = new TaskCompletionSource<EntitiesChangedResponse<Product>>();
            _productService.UpdateEntities<Product>(response => tcs.SetResult(response), new List<Product> { updateProduct1, updateProduct2 });
            return tcs.Task;
        }
