    public class DefaultSourceRepositoryContext
    {
        public SourceA.IRepository SourceARepository => new SourceA.Repository();
        public SourceB.IRepository SourceBRepository => new SourceB.Repository();
        public SourceC.IRepository SourceCRepository => new SourceC.Repository();
    }
