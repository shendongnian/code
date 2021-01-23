    // Where Model1: class Model1 : DbContext {}
    using (var ctx = new Model1())
    {
        // The MyExpressionManipulator is the expression visitor
        // that can "manipulate" expressions and modify them
        Func<Expression, Expression> manipulator = new MyExpressionManipulator().Visit;
        ctx.Parent = new ProxyDbSet<Parent>(ctx.Parent, manipulator);
        ctx.Child1 = new ProxyDbSet<Child1>(ctx.Child1, manipulator);
        // Your query
        var res = ctx.Parent.Where(x => x.Id > 100);
    }
