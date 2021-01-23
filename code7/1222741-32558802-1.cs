     public ExpressionNode Filter2 { get; set; }
     public Expression<Func<TEntity, bool>> Filter { 
            get
            {
                return Filter2.ToBooleanExpression<TEntity>();
            } 
     }
