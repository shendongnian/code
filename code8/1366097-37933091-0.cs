    public interface INotificationUpdateDataProvider
    {
        string UserId { get;  }
        DateTime LastUpdate { get; set; }
    }
    public interface INotificationUpdateService
    {
        DateTime GetLastUpdate();
        void SetLastUpdate(DateTime timesptamp);
    }
