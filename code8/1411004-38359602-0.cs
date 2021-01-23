    interface ICampaignService
    {
        // It's business logic
        // 1. Updates campaign
        // 2. Creates notification using builder
        // 3. Uses notification sender to send notification
        // (4. creates alert object for notification)
        void UpdateCampaignStatus(int campaignId, Status status);
    }
    interface INotificationBuilder
    {
        Notification Build();
    }
    interface INotificationSender
    {
        Send();
    }
    interface IAlertsRepository
    {
        Get();
        GetAll();
        Update();
        Create();
    }
