    class NotifiedForm : Form
    {
    	protected override void OnActivated(EventArgs e)
    	{
    		base.OnActivated(e);
    		NotifierService.OnOk += OnNotifyOK;
    		// similar for other events
    	}
    	protected override void OnDeactivate(EventArgs e)
    	{
    		base.OnDeactivate(e);
    		NotifierService.OnOk -= OnNotifyOK;
    		// similar for other events
    	}
    	protected virtual void OnNotifyOK(object sender, NotifierServiceEventArgs e) { }
        // similar for other events
    }
