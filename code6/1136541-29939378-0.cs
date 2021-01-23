    public void CreateBestPriceListCanExecute()
    {
        CanExecute = DataBaseAccess.connection.State != ConnectionState.Open &&
        DataBaseAccess.connection.State != ConnectionState.Fetching &&
        DataBaseAccess.connection.State != ConnectionState.Executing ? true : false;
    }
