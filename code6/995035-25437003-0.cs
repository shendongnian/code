            public override IQueryable<T1> Apply<T1>(IQueryable<T1> query, Expression<Func<T1, string>> field)
            {   
                //create the constant expression for the value
                ConstantExpression searchValue = Expression.Constant(Value);
                //create the expression for the parameter
                
    //            ParameterExpression parameter = Expression.Parameter(typeof(T1), "t");
                ParameterExpression parameter = field.Parameters.FirstOrDefault();
    
                //create the body -> it is calling the method contains from the field in the field expression, and the value in searchValue
                MethodInfo stringMethod = typeof(string).GetMethods().FirstOrDefault(m => m.Name.Equals("Contains") && m.GetParameters().Count() == 1);
                Expression body = Expression.Call(field.Body, stringMethod, searchValue);
    
                //create the final predicate
                Expression<Func<T1, bool>> predicate = Expression.Lambda<Func<T1, bool>>(body, parameter);
                return query.Where(predicate);
            }
