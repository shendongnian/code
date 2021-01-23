        private void RefreshPurchasedProduct()
        {
            BindingSource bi = new BindingSource();
            //Bla bla
            bi.DataSource = Purchase.PurchasedProducts.
                Join(context.Products, x => x.Product.ID, y => y.ID, (x, y) =>
                    new { y.Product_Name, x.Price, x.Quantity }).ToList();
            //Bla bla
        }
 
