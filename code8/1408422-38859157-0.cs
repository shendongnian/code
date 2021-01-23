    class File {
       ...
       private Product product;
       private Product lastProduct;
    
       public Product Product {
          get { return product; }
          set {
              if (product == value) return;
              lastProduct = Product;
              product = value;
          }
       }
    
       [NotMapped]
       public Product LastProduct {
          get { return lastProduct; }
       }
       ...
    }
