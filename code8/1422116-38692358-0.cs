    abstract class MessageBase { }
    class TextMessage : MessageBase { }
    class ImageMessage : MessageBase { }
    class Receiver<T> where T : MessageBase
    {
        public string GetMessageTitle()
        {
            if (typeof(T) == typeof(TextMessage)) return "Text";
            else if (typeof(T) == typeof(ImageMessage)) return "Image";
            return "Default";
        }
    }
