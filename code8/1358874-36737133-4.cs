    private readonly IMvxMessenger _messenger;
    
    public DetailViewModel(IMvxMessenger messenger) {
    	_messenger = messenger;
    }
    
    public void YourUpdateMethod() {
    	var message = new SelectedItemMessage(this, SelectedItem); //SelectedItem assumed it is a ViewModel property.
    	_messenger.Publish(message, typeof(SelectedItemMessage));
    }
