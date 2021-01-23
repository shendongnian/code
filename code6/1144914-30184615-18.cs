	// Where Model1: class Model1 : ProxyDbContext {}
	using (var ctx = new Model1())
	{
		Func<Expression, Expression> manipulator = new MyExpressionManipulator().Visit;
		ctx.Parent = new ProxyDbSet<Parent>(ctx.Parent, manipulator);
		ctx.Child = new ProxyDbSet<Child>(ctx.Child, manipulator);
		// Your query
		var res = ctx.Parent.Where(x => x.Id > 100);
	}
