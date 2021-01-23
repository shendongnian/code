    public async Task<List<OrderModel>> GetAllByEmailAsync(string email)
    {
        if (orderList == null || orderList.Count() == 0)
            await LoadDbAsync();
        return orderList.Where(c => c.Email == email).ToList();
    }
