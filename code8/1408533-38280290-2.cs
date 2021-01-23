    ObservableCollection<MessageModel> listViewCollection = new ObservableCollection<MessageModel>();
    private enum _MessageType
    {
        Normal,
        Joined
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        listViewCollection.Add(new MessageModel { Message = "hello world!", MessageType = _MessageType.Normal });
        listViewCollection.Add(new MessageModel { Message = "John joined", MessageType = _MessageType.Joined });
    }
