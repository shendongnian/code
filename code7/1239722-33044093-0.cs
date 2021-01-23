    var products = new List<Product>
    {
        new Product { ProductID = 1, Name= "Product 1", Price = 1.00m },
        new Product { ProductID = 2, Name= "Product 2", Price = 1.00m },
        new Product { ProductID = 3, Name= "Product 3", Price = 1.00m },
        new Product { ProductID = 4, Name= "Product 4", Price = 1.00m },
        new Product { ProductID = 5, Name= "Product 5", Price = 1.00m },
        new Product { ProductID = 6, Name= "Product 6", Price = 1.00m }
    };
    var productReviews = new List<ProductReview>
    {
        new ProductReview { ProductReviewID = 1, ProductID = 1, Rating = 5 },
        new ProductReview { ProductReviewID = 2, ProductID = 1, Rating = 3 },
        new ProductReview { ProductReviewID = 3, ProductID = 2, Rating = 1 },
        new ProductReview { ProductReviewID = 4, ProductID = 3, Rating = 4 },
        new ProductReview { ProductReviewID = 5, ProductID = 4, Rating = 2 },
        new ProductReview { ProductReviewID = 6, ProductID = 5, Rating = 5 },
        new ProductReview { ProductReviewID = 7, ProductID = 6, Rating = 4 },
        new ProductReview { ProductReviewID = 8, ProductID = 6, Rating = 3 }
    };
    var averageProductRatings = from review in productReviews
                                group review by review.ProductID into product
                                select new
                                {
                                    ProductId = product.Key,
                                    AverageRating = product.Average(p => p.Rating)
                                };
    var top5 = averageProductRatings.OrderByDescending(average => average.AverageRating).Take(5);
