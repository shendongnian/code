    public interface ISourceRespositoryContext
    {
        SourceA.IRepository SourceARespository { get; }
        SourceB.IRepository SourceBRespository { get; }
        SourceC.IRepository SourceCRespository { get; }
    }
