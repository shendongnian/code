    public sealed class ChatManager
    {
        private static readonly Lazy< ChatManager > lazy =
            new Lazy< ChatManager >(() => new ChatManager());
        
        public static ChatManager Instance { get { return lazy.Value; } }
    
        private ChatManager()
        {
        }
        // TODO add your methods here
    }
