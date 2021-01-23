    public void Delete(IIndexableUniqueId uniqueidvalue)
    {
      using (IProviderDeleteContext deleteContext = ContentSearchManager.GetIndex(Constants.MyIndexName).CreateDeleteContext())
      {
        deleteContext.Delete(uniqueidvalue);
        deleteContext.Commit();
      }
    }
