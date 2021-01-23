    using System.Collections.ObjectModel;
    
    namespace Messaging
    {
        public static class MessageStorage
        {
            public static ObservableCollection<Message> Messages { get; set; }
        }
    }
