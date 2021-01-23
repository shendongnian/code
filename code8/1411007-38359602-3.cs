    interface ICampaignService
    {
        // It's business logic
        // 1. Updates campaign
        // 2. Creates notification using builder
        // 3. Uses notification sender to send notification
        // (4. creates alert object for notification)
        void UpdateCampaignStatus(int campaignId, Status status);
    }
    // Builds different notifications based on different
    // campaign statuses. For instance assign different 
    // email templates and use different text.
    interface INotificationBuilder
    {
        Notification Build();
    }
    interface INotificationSender
    {
        Send(Notification notification);
    }
    interface IAlertsRepository
    {
        Get();
        GetAll();
        Update();
        Create();
    }
