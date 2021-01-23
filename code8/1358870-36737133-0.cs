    private readonly IMvxMessenger _messenger;
	private readonly MvxSubscriptionToken _token;
    
    public MainViewModel(IMvxMessenger messenger) {
    	
    	_messenger = messenger;
    	_token = messenger.Subscribe<SelectedItemMessage>(OnMessageReceived);;
    }
    
    private void OnMessageReceived(SelectedItemMessage obj)
    {
    	SelectedItem = obj.SelectedItem;
    }
