    public static void SO_Question2()
    {
        Parent newParentItem = new Parent() { ID = Guid.NewGuid(), Name = "Parent" };
        newParentItem.Children = new List<Child>();
        List<Child> childItems = new List<Child>() {   
            new Child() { ParentID = newParentItem.ID, ID = Guid.NewGuid(), Name = "Child 1" }, 
            new Child() { ParentID = newParentItem.ID, ID = Guid.NewGuid(), Name = "Child 2" },
            new Child() { ParentID = Guid.NewGuid(),ID = Guid.NewGuid(), Name = "Child 3" } 
        };
        List<Parent> parentCollection = new List<Parent>() { newParentItem }; // In reality this can be a collection of over 2000 items
        // Linq query that I am trying to write using Expressions
        foreach (Parent parentItem in parentCollection)
        {
            childItems.Where(x => x.ParentID == parentItem.ID).ToList().ForEach(y => parentItem.Children.Add(y));
        }
        System.Diagnostics.Debug.WriteLine("Children count from LINQ: " + newParentItem.Children.Count);
        newParentItem.Children.Clear();
        Type parentEntityType = parentCollection.GetType().GetGenericArguments()[0];
        Type childEntityCollType = childItems.GetType();
        Type childEntityType = childEntityCollType.GetGenericArguments()[0];
        Parent parentVariable = parentCollection.First();
        // 1. parentItem.Children.Clear()
        //var childCollection = Expression.Property(Expression.Constant(parentVariable), "Children");
        //Expression clearBody = Expression.Call(childCollection, typeof(List<Child>).GetMethod("Clear"));
        //Delegate bodyLambda = Expression.Lambda(clearBody).Compile();
        //bodyLambda.DynamicInvoke();
        // How can I change 2 and 3 so that they are not recreated with every iteration?
        // My problem is that parentItem changes but is captured in the closure
        //2. (x => x.ParentID == parentItem.ID)
        ParameterExpression predParam = Expression.Parameter(childEntityType, "x");
        Expression left = Expression.Property(predParam, childEntityType.GetProperty("ParentID"));
        Expression right = Expression.Property(Expression.Constant(parentVariable), "ID");
        Expression equality = Expression.Equal(left, right);
        Expression<Func<Child, bool>> le = Expression.Lambda<Func<Child, bool>>(equality, new ParameterExpression[] { predParam });
        Func<Child, bool> compileLambda = le.Compile();
        //3. (y => parentItem.Children.Add(y))
        ParameterExpression feParam = Expression.Parameter(childEntityType, "y");
        Expression addConst = Expression.Constant(parentVariable, parentEntityType);
        Expression childAccessor = Expression.Property(addConst, parentEntityType.GetProperty("Children"));
        Expression body = Expression.Call(childAccessor, "Add", null, feParam);
        Expression<Action<Child>> exp2 = Expression.Lambda<Action<Child>>(body, new ParameterExpression[] { feParam });
        Action<Child> compileExp2 = exp2.Compile();
        foreach (Parent parentItem in parentCollection)
        {
            parentVariable = parentItem;
            childItems.Where(compileLambda).ToList().ForEach(compileExp2);
        }
        System.Diagnostics.Debug.WriteLine("Children count from Expressions: " + parentCollection.First().Children.Count);
    }
