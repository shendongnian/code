    void notifier_NewMessage(object sender, SqlNotificationEventArgs e)
    {
        // Indeed, the RegisterDependency call in the event hanler!
        this.LoadMessage(this.Notifier.RegisterDependency());
    }
