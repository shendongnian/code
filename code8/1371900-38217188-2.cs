    public class Messenger
    {
        public MessengerChannelData ChannelData { get; set; }
    }
    public class MessengerChannelData
    {
        public string notification_type { get; set; }
        public MessengerAttachment attachment { get; set; }
    }
    public class MessengerAttachment
    {
        public string type { get; set; }
        public MessengerPayload payload { get; set; }
    }
    public class MessengerPayload
    {
        public string template_type { get; set; }
        public MessengerElement[] elements { get; set; }
    }
    public class MessengerElement
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string item_url { get; set; }
        public string image_url { get; set; }
        public MessengerButton[] buttons { get; set; }
    }
    public class MessengerButton
    {
        public string type { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string payload { get; set; }
    }
}
