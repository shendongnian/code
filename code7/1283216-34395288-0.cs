    private DateTime _startTime;
    private void StartCommandHandler(object obj)
        {
            _startTime = DateTime.Now;
        }
     private bool CanEnableButton(object arg)
        {
            return _startTime != DateTime.MinValue && DateTime.Now.Subtract(_startTime).Minutes >= 4;
        }
