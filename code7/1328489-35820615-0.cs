    using (eShopEntities db = new eShopEntities()){
    
                IDictionary<long, int> productQuantities = new Dictionary<long, int>(); // supposed your product.ID is of type long
                var list = new List<Product>(db.Products.ToList());
    
                var listFilter = new List<Product>(); 
    
                foreach (var id in list)
                {
                    foreach (var Sessions in SessionData)//got selected products stored in sessions
                    {
                        if (id.ID == Sessions)
                        {
                            if (!productQuantities.ContainsKey(id.ID)) // new
                            { 
                             listFilter.Add(id); //Add all selected products(via session)
                             productQuantities.Add(id.ID, 1)
                            } // new else {
                             productQuantities[id.ID]++; // new                         
                            }
                        }
                    }
                }
    
                int TotSum = 0;
                foreach (var sum in listFilter)
                {
                    // TotSum = TotSum + sum.Price; // old
    
                    sum.Quantity = productQuantities[id.ID]; // supposed your class Product has corresponding property for quantities
                    TotSum = TotSum + sum.Price * sum.Quantity;
                }
    
                cartListView.DataSource = listFilter; cartListView.DataBind();
    
                lblSum.Text = TotSum.ToString();
    
    
               }
