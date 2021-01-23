    public IQueryable<FileRequest> Test2(long fileId, 
        Expression<Func<FileRequest, bool>> predicate)
    {
        return context.FileRequest.Include("AddInfo")
            .Where(x=>x.FileId == fileId)
            .Where(predicate);
    }
