	using (SandboxContext dbc = new SandboxContext())
	{	
		return dbc.Customer.Join(dbc.Product,
                     c => c.CustomerKey,
                     p => p.CustomerKey,
                     (c, p) => new { Customer = c, Product = p})
                  .Count();
	}
