        public class TelegramBoApiMainObject
        {
            public Boolean ok { get; set; }
            public List<TelegramBotApiResult> result { get; set; }
        }
    
        public class TelegramBotApiResult
        {
            public Int32 update_id { get; set; }
            public TelegramBotApiMessage message { get; set; }
        }
    
        public class TelegramBotApiMessage
        {
            public Int32 message_id { get; set; }
            public TelegramBotApiFrom from { get; set; }
            public TelegramBotApiChat chat { get; set; }
            public Int32 date { get; set; }
            public String text { get; set; }
        }
    
        public class TelegramBotApiFrom
        {
            public Int32 id { get; set; }
            public String first_name { get; set; }
        }
    
        public class TelegramBotApiChat
        {
            public Int32 id { get; set; }
            public String first_name { get; set; }
            public String title { get; set; }
        }
