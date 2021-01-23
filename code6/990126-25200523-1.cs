    public static async Task<string> UpdateAsync(Customer obj)
    {
        NorthwindEntities db = new NorthwindEntities();
        // This is an async method
        Customer existing = await db.Customers.FindAsync(obj.CustomerID);         
        existing.CompanyName = obj.CompanyName;
        existing.ContactName = obj.ContactName;
        existing.Country = obj.Country;
        await db.SaveChangesAsync(); // This is an async method
        return "Customer updated successfully!";
    }
