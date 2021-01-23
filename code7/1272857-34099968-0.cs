    [ImplementPropertyChanged]
	public class HomeViewModel : BaseViewModel
	{
        // every property will notify changes
		public string Foo { get; set; }
    }
    [ImplementPropertyChanged]
	public class ChatMessage
	{
		public string Uid { get; set; }
		public DateTime? SentAt { get; set; }
		public string SenderConnectionId { get; set; }
		public string UserName { get; set; }
		public string Content { get; set; }
    }
