    public event EventHandler OnRemoveContact;
    
    private void RemoveContactButton_OnClick(object sender, RoutedEventArgs e)
    {
    	//... your existing code here
    	OnRemoveContact?.Invoke(this, new EventArgs());
    }
