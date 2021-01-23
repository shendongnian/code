    public class BlProduct
    {
        public List<Product> Select()
        {
            EFDbContext context = new EFDbContext();
            try
            {
                return (from a in context.Product Select a).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
