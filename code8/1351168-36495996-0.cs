    public static async Task<IEnumerable<Blogs>>
        GetAllBlogsAsync(EfDataContext db)
    {
        try
        {
            // If a fault occurs in the linq query, the 
            // exception is raised by the 'await' statement
            return await db.Blogs
                .OrderByDescending(b => b.Date)
                .SelectAsync();
        }
        catch (Exception ex)
        {
            throw new BlogLibraryException("This blog appears to be broken.", ex);
        }
    }
