    abstract class Message
    {
    }
    class FileHandlerMessage : Message
    {
        public string FileName { get; set; }
    }
