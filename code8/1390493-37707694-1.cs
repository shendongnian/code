	public new virtual void Clear()
	{
		base.Clear();
		this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		RaisePropertyChanged(new PropertyChangedEventArgs("Count"));
	}
	public new virtual T Pop()
	{
		var item = base.Pop();
		this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
		RaisePropertyChanged(new PropertyChangedEventArgs("Count"));
		return item;
	}
	public new virtual void Push(T item)
	{
		base.Push(item);
		this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
		RaisePropertyChanged(new PropertyChangedEventArgs("Count"));
	}
