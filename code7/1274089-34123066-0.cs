	public async Task<List<OrderModel>> GetByEmailAsync(string email)
	{
		if (orderList == null)
			await LoadDbAsync();
		return orderList
				.Where(c => c.Email == email)
				.ToList();
	}
