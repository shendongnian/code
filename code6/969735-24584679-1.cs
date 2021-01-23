    public class OrderRepository
    {
        public IList<BindableRecord> Get()
        {
            using (AdventureWorks2012Entities1 ctx = new AdventureWorks2012Entities1())
            {
                return (from c in ctx.Customers
                        join o in ctx.Orders on c.Order equals o
                        join ct in ctx.CustomerTypes on c.CustomerType equals ct
                        select new BindableRecord() { CustomerObject = c, CustomerTypeObject = ct, OrderObject = o }).ToList();
            }
        }
        public void Save(IEnumerable<BindableRecord> entities)
        {
            using (EntityContext ctx = new EntityContext())
            {
                foreach (var entity in entities)
                {
                    ctx.Entry(entity.CustomerTypeObject).State = EntityState.Modified;
                    ctx.Entry(entity.CustomerObject).State = EntityState.Modified;
                    ctx.Entry(entity.OrderObject).State = EntityState.Modified;
                }
                ctx.SaveChanges();
            }
        }
    }
