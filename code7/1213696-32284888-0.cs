    public static Expression<Func<TDest,bool>> 
          ConvertTo<TSrc,TDest>(Expression<Func<TSrc,bool>> srcExp)
    {
        ParameterExpression destPE = Expression.Parameter(typeof(TDest));
        ExpressionConverter ec = new ExpressionConverter(typeof(TSrc),destPE);
        Expression body = tc.Visit(srcExp.Body);
        return Expression.Lambda<Func<TDest,bool>>(body,destPE);
    } 
    public class ExpressionConverter: ExpressionVisitor{
        private Type srcType;
        private ParameterExpression destParameter;
        public ExpressionConverter(Type src, ParameterExpression dest){
            this.srcType = src;
            this.destParameter= dest;
        } 
        protected override Expression 
           VisitParameter(ParameterExpression node)
        {
            if(node.Type == srcType)
                return this.destParameter;
            return base.VisitParameter(node);
        }
    }
