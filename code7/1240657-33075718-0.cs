    public class BlProduct
    {
        public List<Product> Select()
        {
            EFDbContext context = new EFDbContext();
            try
            {
                return (from a in context.Users Product a).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
