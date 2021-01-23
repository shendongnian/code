    public event EventHandler MyCoolEvent;
    private void TestButton_Click(object sender, RoutedEventArgs e)
    {
        OnMyCoolEvent();
    }
    
    protected virtual void OnMyCoolEvent()
    {
        EventHandler handler = MyCoolEvent;
        if (handler != null) handler(this, EventArgs.Empty);
    } 
