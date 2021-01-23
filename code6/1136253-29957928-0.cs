    container.RegisterType<IDatabaseManagement, DatabaseManagement>(
        new InjectionFactory(c =>
        {
            var connectionInfo = c.Resolve<IConnectionInfo>();
            var userInfo = c.Resolve<IUserInfo>();
            return new DatabaseManagement(
                connectionInfo.Connection,
                userInfo.CurrentUser.UserEmployeeNumber);
        }));
