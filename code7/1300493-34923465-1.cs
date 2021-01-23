    using (container.BeginScope())
    {
        var db = container.Resolve<DataConnection>();
        db.BeginTransaction();
        container.Resolve<IData<Vehicle>>().Update(...);
        container.Resolve<IData<Vehicle>>().Update(...);
        container.Resolve<IData<Vehicle>>().Update(...);
        db.CommitTransaction();
    }
