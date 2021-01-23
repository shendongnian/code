        tbl_Product.Select(prod => 
             new ProductModel
                { 
                       id = prod.id,
                       name = prod.name,
                       price = prod.price,
                       images = prod.tbl_image.Select(img => new ImageModel
                                               {
                                                  id = img.id,
                                                  imageUrl = img.imageUrl
                                                })
                }).ToList()
