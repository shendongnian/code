        config.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider, typeof(SingletonConnectionProvider).AssemblyQualifiedName);
        /// <summary>
        /// ensures that the same connection is used for all sessions. Useful for in-memory databases like sqlite
        /// </summary>
        public class SingletonConnectionProvider : DriverConnectionProvider
        {
            private IDbConnection _theConnection;
            public override void CloseConnection(IDbConnection conn)
            {
            }
            public override IDbConnection GetConnection()
            {
                if (_theConnection == null)
                {
                    _theConnection = base.GetConnection();
                }
                return _theConnection;
            }
        }
