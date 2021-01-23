    public interface ISourceRepositoryContext
    {
        SourceA.IRepository SourceARespository { get; }
        SourceB.IRepository SourceBRespository { get; }
        SourceC.IRepository SourceCRespository { get; }
    }
