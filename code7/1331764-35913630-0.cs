    public class MyObject
    {
        public Message Message { get; set; }
        public List<Error> Errors { get; set; }
        public int FileInflected { get; set; }
        public string Path { get; set; }
    }
    public class Message
    {
        public string Name { get; set; }
    }
    public class Error
    {
        //Whatever you want
    }
