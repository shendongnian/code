	public sealed class QueryProcessor : IQueryProcessor
	{
		private readonly IHandlerFactory handlerFactory;
		public QueryProcessor(IHandlerFactory handlerFactory)
		{
			if (handlerFactory == null)
				throw new ArgumentNullException("handlerFactory");
			
			this.handlerFactory = handlerFactory;
		}
		//[DebuggerStepThrough]
		public TResult Process<TResult>(IQuery<TResult> query)
		{
			var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
			dynamic handler = this.handlerFactory.Create(handlerType);
			try
			{
				return handler.Handle((dynamic)query);
			}
			finally
			{
				this.handlerFactory.Release(handler);
			}
		}
	}
