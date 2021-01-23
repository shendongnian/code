	// Where Model1: class Model1 : ProxyDbContext {}
	using (var ctx = new Model1())
	{
		// Your query
		var res = ctx.Parent.Where(x => x.Id > 100);
		// The query is automatically manipulated by your Manipulate method
	}
