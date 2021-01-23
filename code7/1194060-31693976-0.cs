    public static void SO_Question()
        {
            Parent parentItem = new Parent() { ID = Guid.NewGuid(), Name = "Parent" };
            parentItem.Children = new List<Child>();
            List<Child> childItems = new List<Child>() {   
                new Child() { ParentID = parentItem.ID, ID = Guid.NewGuid(), Name = "Child 1" }, 
                new Child() { ParentID = parentItem.ID, ID = Guid.NewGuid(), Name = "Child 2" },
                new Child() { ParentID = Guid.NewGuid(),ID = Guid.NewGuid(), Name = "Child 3" } 
            };
            // Linq query that I am trying to write using Expressions
            childItems.Where(x => x.ParentID == parentItem.ID).ToList().ForEach(y => parentItem.Children.Add(y));
            System.Diagnostics.Debug.WriteLine("Children count from LINQ: " + parentItem.Children.Count);
            parentItem.Children.Clear();
            Type parentEntityType = parentItem.GetType();
            Type childEntityCollType = childItems.GetType();
            Type childEntityType = childEntityCollType.GetGenericArguments()[0];
            //1. (x => x.ParentID == parentItem.ID)
            ParameterExpression predParam = Expression.Parameter(childEntityType, "x");
            Expression left = Expression.Property(predParam, childEntityType.GetProperty("ParentID"));
            Expression right = Expression.Property(Expression.Constant(parentItem), "ID");
            Expression equality = Expression.Equal(left, right);
            LambdaExpression le = Expression.Lambda(equality, new ParameterExpression[] { predParam });
            //2. childItems.Where(x => x.ParentID == parentItem.ID)
            Expression targetConstant = Expression.Constant(childItems, childEntityCollType);
            Expression whereBody = Expression.Call(typeof(Enumerable), "Where", new Type[] { childEntityType }, targetConstant, le);
            Func<IEnumerable> whereLambda = Expression.Lambda<Func<IEnumerable>>(whereBody).Compile();
            object whereResult = whereLambda.Invoke();
            //3. childItems.Where(x => x.ParentID == parentItem.ID).ToList()
            Expression toListConstant = Expression.Constant(whereResult, whereResult.GetType());
            Expression toListBody = Expression.Call(typeof(Enumerable), "ToList", new Type[] { childEntityType }, toListConstant);
            Func<IEnumerable> listLambda = Expression.Lambda<Func<IEnumerable>>(toListBody).Compile();
            object toListResult = listLambda.Invoke();
            //5. (y => parentItem.Children.Add(y))
            ParameterExpression feParam = Expression.Parameter(childEntityType, "y");
            Expression addConst = Expression.Constant(parentItem, parentEntityType);
            Expression childAccessor = Expression.Property(addConst, parentEntityType.GetProperty("Children"));
            Expression body = Expression.Call(childAccessor, "Add", null, feParam);
            LambdaExpression exp2 = Expression.Lambda(body, new ParameterExpression[] { feParam });
            //6. childItems.Where(x => x.ParentID == parentItem.ID).ToList().ForEach(y => parentItem.Children.Add(y));
            Expression targetConst2 = Expression.Constant(toListResult, toListResult.GetType());
            Expression whereBody2 = Expression.Call(targetConst2, toListResult.GetType().GetMethod("ForEach"), exp2);
            Delegate d = Expression.Lambda(whereBody2).Compile();
            d.DynamicInvoke();
            System.Diagnostics.Debug.WriteLine("Children count from Expressions: " + parentItem.Children.Count);
        }
