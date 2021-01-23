    _projector = new SqlProjector(
       Resolve.WhenEqualToHandlerMessageType(new PortfolioProjection()),
       new TransactionalSqlCommandExecutor(
         new ConnectionStringSettings(
           "projac",
            @"Data Source=(localdb)\ProjectsV12;Initial Catalog=ProjacUsage;Integrated Security=SSPI;",
            "System.Data.SqlClient"),
          IsolationLevel.ReadCommitted));
