    public interface IQuery<TResult> { }
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        // Note the Task<T> here
        Task<TResult> Handle(TQuery query);
    }
