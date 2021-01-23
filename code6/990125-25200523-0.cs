    public static async Task<string> UpdateAsync(Customer obj)
    {
        NorthwindEntities db = new NorthwindEntities();
        Customer existing = await db.Customers.FindAsync(obj.CustomerID); // This is an async method
        existing.CompanyName = obj.CompanyName;
        existing.ContactName = obj.ContactName;
        existing.Country = obj.Country;
        await db.SaveChangesAsync(); // This is an async method
        return "Customer updated successfully!";
    }
