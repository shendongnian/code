    public interface IDataSource<TInput, TOutput> where TInput: InputBase
    {
        IEnumerable<TOutput> GetData(TOutput input);
    }
    public interface IDataCommand<TInput> where TInput:InputBase
    {
        void PostData(TInput Input);
    }
