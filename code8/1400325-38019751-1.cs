    // Include this namespace:
    using System.Data.Entity;
    // Instruct the user query to also load Conditions.
    result = context.Users
        .Include(u => u.Conditions)  // Ensure Conditions loaded with query
        .FirstOrDefault(x => x.Id == id);
