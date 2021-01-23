    public async Task<Customer[]> getGustomerAsync(int[] customerIds)
    {
        Customer[] customers = new Customer[customerIds.Length];
        await Task.Run(() => System.Threading.Tasks.Parallel.ForEach(customerIds, r =>
        {
            customers[r] = getGustomer(r);
        }));
        return customers;
    }
