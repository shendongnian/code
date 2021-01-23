    List<ArchiveProcess> query;
    using (ArchiveVMADDatabase.ArchiveDatabaseModel dataContext = new ArchiveDatabaseModel())
    {
         query = (from history in dataContext.ArchiveProcess.AsNoTracking()
                     orderby history.ArchiveBegin descending
                     select history).Take(10).ToList();
    
        return query; /// you do not really need to all enumerable  as IOrderedEnumerable<ArchiveProcess>;
    }
