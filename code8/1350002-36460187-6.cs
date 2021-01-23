    public void AddItem (Product product, int quantity)
    {
          // Create an instance of your line
          var line = lineCollection.FirstOrDefault(p => p.Product.ProductID == product.ProductID);
          if (line == null)
          {
               // Is lineCollection some global or static variable?
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity  });
          }
          else
          {
               // Since line is actually created (and scoped) to this
               // method, this really isn't going to do anything
               // as line will be disposed of upon exiting this method
               line.Quantity += quantity;
          }
    }
