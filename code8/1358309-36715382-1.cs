    public FirstViewModel()
    {
        ScanMessage.Instance.MessageReceived += ScanMessage_MessageReceived;
    }
    private void ScanMessage_MessageReceived(string message)
    {
        //Do something
    }
