    public class OrderRepository
    {
        public IList<BindableRecord> Get()
        {
            using (EntityContext ctx = new EntityContext())
            {
                return (from c in ctx.Customers
                        join o in ctx.Orders on c.Order equals o
                        join ct in ctx.CustomerTypes on c.CustomerType equals ct
                        select new BindableRecord() { CustomerObject = c, CustomerTypeObject = ct, OrderObject = o }).ToList();
            }
        }
		public void Save(IEnumerable<BindableRecord> addOrUpdateEntities, IEnumerable<BindableRecord> deletedEntities)
		{
			using (EntityContext ctx = new EntityContext())
			{
				foreach (var entity in addOrUpdateEntities)
				{
					ctx.Entry(entity.CustomerTypeObject).State = entity.CustomerTypeObject.IdCustomerType == default(int) ? EntityState.Added : EntityState.Modified;
					ctx.Entry(entity.CustomerObject).State = entity.CustomerObject.IdCustomer == default(int) ? EntityState.Added : EntityState.Modified;
					ctx.Entry(entity.OrderObject).State = entity.OrderObject.IdOrder == default(int) ? EntityState.Added : EntityState.Modified;
				}
				foreach (var entity in deletedEntities)
				{
					ctx.Entry(entity.CustomerTypeObject).State = EntityState.Deleted;
					ctx.Entry(entity.CustomerObject).State = EntityState.Deleted;
					ctx.Entry(entity.OrderObject).State = EntityState.Deleted;
				}
				ctx.SaveChanges();
			}
		}
    }
