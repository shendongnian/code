    interface ITransformResult<T>
    {
        
    }
    interface ITransformable<T>
    {
        
    }
    interface ITransformInclude<T>
    {
    }
    interface ITransformer<T>
    {
        ITransformResult<T> Transform(ITransformable<T> data);
        bool HasIncludes { get; }
        IEnumerable<ITransformInclude<T>> FireIncludes(ITransformable<T> data);
    }
    class TransformedData<T>
    {
        public ITransformResult<T> Result { get; set; }
        public IEnumerable<ITransformInclude<T>> Includes { get; set; }
    }
