    public class ChatViewModel
    {
        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();
        internal void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
