    public IEnumerable<ArchiveProcess> getHistory()
    {
      using (ArchiveVMADDatabase.ArchiveDatabaseModel dataContext = new ArchiveDatabaseModel())
      {
        return (from history in dataContext.ArchiveProcess.AsNoTracking()
                     orderby history.ArchiveBegin descending
                     select history).Take(10).ToList();
      }
    }
