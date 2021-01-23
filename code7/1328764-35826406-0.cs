     {
                decimal TotalPrice = 0.0;
                decimal TotalProducts = 0.0;
                foreach (DataListItem product in dlBasketItems.Items)
                {
                    Label PriceLabel = product.FindControl("lblProductPrice") as Label;
                    TextBox ProductQuantity = product.FindControl("txtProductQuantity") as TextBox;
    
                    
                    decimal ProductPrice = Convert.ToDecimal(PriceLabel.Text) *
                        Convert.ToInt32(ProductQuantity.Text);                    
                    
                    TotalPrice = TotalPrice + ProductPrice;
                    TotalProducts = TotalProducts + Convert.ToInt32(ProductQuantity.Text);
                 }
                txtTotalPrice.Text = Convert.ToString(TotalPrice);
                txtTotalProducts.Text = Convert.ToString(TotalProducts);
            }    
            
