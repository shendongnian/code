	public class Dealer1
	{
		internal IQueryable<vmDealer> getDealer_query(DAL.DBConn_Nav db)
		{
			return
				from d in db.DENTALICA_S_P_A__Customer
				select new vmDealer()
				{
					idDealer = d.No_,
					name = String.Join(" ", d.Name, d.Name_2)
				};
		}
	}
	
	public class Customer1
	{
		internal IQueryable<vmDealer> getCustomerForOperator_query(DAL.DBConn_Nav db)
		{
			return new Dealer1().getDealer_query(db).Where(i => i.name.StartsWith("AAA"));
		}
	
		public List<vmDealer> getCustomerForOperator()
		{
			using (var db = new DAL.DBConn_Nav())
			{
				return getCustomerForOperator_query(db).ToList();
			}
		}
	}
