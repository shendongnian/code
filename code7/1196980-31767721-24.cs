    public interface ISourceRepositoryContext
    {
        SourceA.IRepository SourceARepository { get; }
        SourceB.IRepository SourceBRepository { get; }
        SourceC.IRepository SourceCRepository { get; }
    }
