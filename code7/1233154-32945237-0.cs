    public class NavigationFilterAttribute : ActionFilterAttribute
    {
        private readonly Type _navigationFilterType;
        class NavigationPropertyFilterExpressionVisitor : ExpressionVisitor
        {
            private Type _navigationFilterType;
            public bool ModifiedExpression { get; private set; }
            public NavigationPropertyFilterExpressionVisitor(Type navigationFilterType)
            {
                _navigationFilterType = navigationFilterType;
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                // Check properties that are of type ICollection<T>.
                if (node.Member.MemberType == System.Reflection.MemberTypes.Property
                    && node.Type.IsGenericType
                    && node.Type.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    var collectionType = node.Type.GenericTypeArguments[0];
                    // See if there is a static, public method on the _navigationFilterType
                    // which has a return type of Expression<Func<T, bool>>, as that can be
                    // handed to a .Where(...) call on the ICollection<T>.
                    var filterMethod = (from m in _navigationFilterType.GetMethods()
                                        where m.IsStatic
                                        let rt = m.ReturnType
                                        where rt.IsGenericType && rt.GetGenericTypeDefinition() == typeof(Expression<>)
                                        let et = rt.GenericTypeArguments[0]
                                        where et.IsGenericType && et.GetGenericTypeDefinition() == typeof(Func<,>)
                                            && et.GenericTypeArguments[0] == collectionType
                                            && et.GenericTypeArguments[1] == typeof(bool)
                                        // Make sure method either has a matching PropertyDeclaringTypeAttribute or no such attribute
                                        let pda = m.GetCustomAttributes<PropertyDeclaringTypeAttribute>()
                                        where pda.Count() == 0 || pda.Any(p => p.DeclaringType == node.Member.DeclaringType)
                                        // Make sure method either has a matching PropertyNameAttribute or no such attribute
                                        let pna = m.GetCustomAttributes<PropertyNameAttribute>()
                                        where pna.Count() == 0 || pna.Any(p => p.Name == node.Member.Name)
                                        select m).SingleOrDefault();
                        
                    if (filterMethod != null)
                    {
                        // <node>.Where(<expression>)
                        var expression = filterMethod.Invoke(null, new object[0]) as Expression;
                        var whereCall = Expression.Call(typeof(Enumerable), "Where", new Type[] { collectionType }, node, expression);
                        ModifiedExpression = true;
                        return whereCall;
                    }
                }
                return base.VisitMember(node);
            }
        }
        public NavigationFilterAttribute(Type navigationFilterType)
        {
            _navigationFilterType = navigationFilterType;
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage response = actionExecutedContext.Response;
            if (response != null && response.IsSuccessStatusCode && response.Content != null)
            {
                ObjectContent responseContent = response.Content as ObjectContent;
                if (responseContent == null)
                {
                    throw new ArgumentException("HttpRequestMessage's Content must be of type ObjectContent", "actionExecutedContext");
                }
                // Take the query returned to us by the EnableQueryAttribute and run it through out
                // NavigationPropertyFilterExpressionVisitor.
                IQueryable query = responseContent.Value as IQueryable;
                if (query != null)
                {
                    var visitor = new NavigationPropertyFilterExpressionVisitor(_navigationFilterType);
                    var expressionWithFilter = visitor.Visit(query.Expression);
                    if (visitor.ModifiedExpression)
                        responseContent.Value = query.Provider.CreateQuery(expressionWithFilter);
                }
            }
        }
    }
