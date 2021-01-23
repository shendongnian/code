    public class Message
    {
        [TypeConverter(typeof(UserConverter))]
        public SenderId SenderId { get; set; }
    }
