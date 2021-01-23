    public abstract class BaseImporter<TEntity, TFileData> : IImporter<TEntity> 
          where TEntity : class 
          where TFileData: IFileData
    {
            //don't pay attention to this method
            public TEntity SomeMethodWhichUsesTEntity()
            {
                return null;
            }
        
            // changed IFileData to TFileData
            protected abstract IBaseReader<TFileData> GetReader(Stream file, params object[] args);
    }
