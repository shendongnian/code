    var session = GetCurrentNHibernateSession();
    return Task.Factory.StartNew(() => {
        var dataProvider = DataProviderImplGeneric<UserModel, int>(session);
        return dataProvider.Save(user);
    }
