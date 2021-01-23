    List<TopRated> TopRated = (from review in db.ProductReviews
                            group review by review.ProductID into product
                            select new 
                            {
                              FirstProduct=product.FirstOrDefault(p=>p.Products)
                              ProductId = product.Key,
                              AverageRating = product.Average(p => p.Rating)
                            }).Select(product=>new TopRated {
                              ProductName = product.FirstProduct.Name,
                              Price = product.FirstProduct.Price,
                              PriceOffer = product.FirstProduct.PriceOffer,
                              ProductId = product.ProductId,
                              AverageRating = product.AverageRating
                            }).ToList();
