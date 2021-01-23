    foreach (var eligibleProduct in productEligibiltyes)
            { 
              Products products= new Products();
              products.ProductId=eligibleProduct.ProductId;
              products.ProductEligiblity.Add(eligibleProduct);
              Product.Attach(products);
              Entry(products).State = EntityState.Modified;
              Product.Add(products);
           }
