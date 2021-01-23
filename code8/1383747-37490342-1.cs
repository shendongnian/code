    private static ChannelFactory<IRepositoryService> GetRepositoryServiceChannelFactory( )
    {
      lock ( s_sync )
      {
        if ( s_repositoryServiceChannelFactory == null )
        {
          s_repositoryServiceChannelFactory = new ChannelFactory<IRepositoryService>( Properties.Settings.Default.ConfigName );
        }
      }
      return s_repositoryServiceChannelFactory;
    }
