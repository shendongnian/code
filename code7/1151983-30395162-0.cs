    [ImplementPropertyChanged]
    public class ChatInfo : IMessageData
    {
      public ObservableCollection<Message> messages { get; set; }
      messages.CollectionChanged += new
      System.Collections.Specialized.NotifyCollectionChangedEventHandler(MessageChanged);
      [JsonIgnore]
      public Message LastMessage {get; private set;}
      private void MessageChanged(object sender, NotifyCollectionChangedEventArgs e) 
      {
       //set the property here
       LastMessage = messages.Last();
      }
    }
