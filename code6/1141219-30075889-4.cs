    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using FluentValidation;
    using FluentValidation.Attributes;
    using FluentValidation.Internal;
    
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<TModel, TProperty> ApplyChainValidation<TModel, TProperty>(this IRuleBuilderOptions<TModel, TProperty> builder, Expression<Func<TModel, TProperty>> expr)
        {
            // with name string
            var firstMember = PropertyChain.FromExpression(expr).ToString().Split('.')[0]; // PropertyChain is internal FluentValidation class
            // create stack to collect model properties from property chain since parents to childs to check for null in appropriate order
            var reversedExpressions = new Stack<Expression>();
            var getMemberExp = new Func<Expression, MemberExpression>(toUnwrap =>
            {
                if (toUnwrap is UnaryExpression)
                {
                    return ((UnaryExpression)toUnwrap).Operand as MemberExpression;
                }
                return toUnwrap as MemberExpression;
            }); // lambda from PropertyChain implementation
            var memberExp = getMemberExp(expr.Body);
            var firstSkipped = false;
            // check only parents of property to validate
            while (memberExp != null)
            {
                if (firstSkipped)
                {
                    reversedExpressions.Push(memberExp); // don't check target property for null
                }
                firstSkipped = true;
                memberExp = getMemberExp(memberExp.Expression);
            }
            // build expression that check parent properties for null
            var currentExpr = reversedExpressions.Pop();
            var whenExpr = Expression.NotEqual(currentExpr, Expression.Constant(null));
            while (reversedExpressions.Count > 0)
            {
                whenExpr = Expression.AndAlso(whenExpr, Expression.NotEqual(currentExpr, Expression.Constant(null)));
                currentExpr = reversedExpressions.Pop();
            }
            var parameter = expr.Parameters.First();
            var lambda = Expression.Lambda<Func<TModel, bool>>(whenExpr, parameter); // use parameter of source expression
            var compiled = lambda.Compile();
            return builder
              .WithName(firstMember)
              .When(model => compiled.Invoke(model));
        }
    }
