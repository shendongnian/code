        /// <summary>
        /// Returns either a ProductFormula, if it exists for the specified Product, otherwise a general CategoryFormula.
        /// </summary>
        static dynamic RetrieveFormula(int productId)
        {
            // First, we need to combine the entities 'Product' with 'ProductVariant'. 
            // This because we need the 'SKU' to check if a ProductFormula exists:
            var combinedProducts = AllProducts.Join(
                
                // join 'Products' and 'ProductVariants'
                AllProductVariants, 
                product => product.Id,
                productvariant => productvariant.ProductId,
                (product, productvariant) => new {
                    Product = product,
                    Variant = productvariant
                })
                // create a 'merged', anonymous object which holds all the info we need
                .Select(p => new
                {
                    ProductId = p.Product.Id,
                    CategoryId = p.Product.CategoryId,
                    SKU = p.Variant.SKU
                });    
            
            // With this in place, we can now fetch the requested record by 'productId'
            var product = combinedProducts.Single(p => p.ProductId == productId);
            // Finally, check if there's a ProductFormula
            if (AllProductFormulas.Any(p => p.SKU == product.SKU))
                // yes, there's a ProductFormula so return it
                return AllProductFormulas.Single(pv => pv.SKU == product.SKU);
            else
                // no, sorry - simply return the CategoryFormula instead
                return AllCategoryFormulas.Single(c => c.Id == product.ProductId);
        }
