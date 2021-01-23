    var allProducts = readProducts.Select(line => line.Split(','))
                                  .Select(array => new Product {
                                                  productCode   = array[0],
                                                  productName   = array[1],
                                                  amountInStock = array[2], 
                                                      // etc.
                                                  }
