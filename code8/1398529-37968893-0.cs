    public void raisePropertyChanged(string propertyName)
    {
    	if (!this.areChangeNotificationsEnabled())
    		return;
    
    	var changed = new ReactivePropertyChangedEventArgs<TSender>(sender, propertyName);
    	sender.RaisePropertyChanged(changed);
    
    	this.notifyObservable(sender, changed, this.changedSubject);
    }
