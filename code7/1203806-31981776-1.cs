	public static async Task<Product> GetProductAndReviewsAsync(
				int productID, int reviewsToGet)
	
	{
		using (SqlConnection connection = new SqlConnection(ConnectionString))
		{
			await connection.OpenAsync();
			const string commandString = GetProductByIdCommand + ";" 
										+ GetProductReviewsPagedById;
			
			using (SqlCommand command = new SqlCommand(commandString, connection))
			{
				command.Parameters.AddWithValue("productid", productID);
				command.Parameters.AddWithValue("reviewStart", 0); 
				command.Parameters.AddWithValue("reviewCount", reviewsToGet);
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					if (await reader.ReadAsync())
					{
						Product product = GetProductFromReader(reader, productID);
						if (await reader.NextResultAsync())
						{
							List<Review> allReviews = new List<Review>();
							while (await reader.ReadAsync())
	
							{
								Review review = GetReviewFromReader(reader);
								allReviews.Add(review);
							}
							product.Reviews = allReviews.AsReadOnly();
							return product;
						}
						else
						{
							throw new InvalidOperationException(
								"Query to server failed to return list of reviews");
						}
					}
					else
					{
						return null;
					}
				}
			}
		}
	}
	
