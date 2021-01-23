    var allProducts = readProducts.Select(line => line.Split(','))  // collection of string arrays
                                  .Select(array => new Product {
                                                  productCode   = array[0],
                                                  productName   = array[1],
                                                  amountInStock = array[2], 
                                                      // etc.
                                                  });  // collection of Products
