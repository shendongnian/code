    private ObservableCollection<MessageEntity> messageList;
    private ObservableCollection<ChatEntity> ChatList;
    
    public MainPage()
    {
        this.InitializeComponent();
        messageList = new ObservableCollection<MessageEntity>();
        ChatList = new ObservableCollection<ChatEntity>();
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        ChatList.Add(new ChatEntity { Member = "Tom", MessageList = messageList });
        ChatList.Add(new ChatEntity { Member = "Peter" });
        ChatList.Add(new ChatEntity { Member = "Clark" });
    }
    
    private void MasterListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        messageList.Clear();
        for (int i = 0; i < 100; i++)
        {
            if (i % 2 == 0)
                messageList.Add(new MessageEntity { Member = "Tom", Content = "Hello!", MessageType = MessageEntity.MsgType.From });
            else
                messageList.Add(new MessageEntity { Content = "World!", MessageType = MessageEntity.MsgType.To });
        }
        var listView = FindChildOfType<ListView>(DetailContentPresenter);
        listView.ScrollIntoView(messageList.Last());
    }
