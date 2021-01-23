    class FooRepository
    {
       public async Task<List<FooDTO>> FindAsync()
       {
           using(var context = new DbContext())
           {
               return await context.Foos
                   .Select(m => new FooDTO
                   {
                       Id = m.Id,
                       ...
                   })
                   .ToListAsync();
           } 
       }
    }
