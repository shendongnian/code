        public bool UpdateProduct(int id, Product product)
        {
            if (product != null) System.Diagnostics.Debug.WriteLine("UpdateProduct() [" + id + "] " + product.ToString());
            if (id == 0) return AddProduct(product);
            try
            {
                Product ctxProduct = GetProductIncludingProductLists(id);
                if (ctxProduct != null && product != null)
                {
                    ctxProduct.CUSIP = product.CUSIP;
                    ctxProduct.SEDOL = product.SEDOL;
                    ctxProduct.BUID = product.BUID;
                    ctxProduct.Key = product.Key;
                    ctxProduct.Track = product.Track;
                    ctxProduct.ProductLists = new List<ProductList>();
                    foreach (ProductList pl in product.ProductLists)
                        ctxProduct.ProductLists.Add(pl.ProductListId == 0 
                                                    ? pl 
                                                    : GetProductList(pl.ProductListId));
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Update Product Error: " + e.Message + "\nInner: " + e.InnerException);
                return false;
            }
        }
