    // This needs to be a class variable (not local)
    private Queue<NotificationMessage> notificationMessages = new Queue<NotificationMessage>();
    
    
    void LoadMessages()
    {
        private string _orderUrl;
        this.notificationMessages = JsonConvert.DeserializeObject<IEnumerable<NotificationMessage>>(response);
    
       ShowNextMessage();
    }
    
    void ShowNextMessage()
    {
        if (notificationMessages.Count == 0) return;
        var notificationMessage = notificationMessages.Dequeue();
    
        bool success = notificationMessage.Success;
        string type = notificationMessage.Type;
        string message = notificationMessage.Message;
        _orderUrl = notificationMessage.OrderUrl;
    
        if (success)
        {
            _notifyIcon.BalloonTipTitle = BalloonTitle;
            _notifyIcon.BalloonTipText = type + @": " + message;
            _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            _notifyIcon.BalloonTipClicked += BalloonTip_Click;
            _notifyIcon.ShowBalloonTip(10000);
    
            SystemSounds.Exclamation.Play();
        }
    }
    
    void BalloonTip_Click(object sender, EventArgs e)
    {
        string urlBase = ConfigurationManager.AppSettings["UrlBase"];
        string target = urlBase + _orderUrl;
        System.Diagnostics.Process.Start(target);
    
        ShowNextMessage();
    }
