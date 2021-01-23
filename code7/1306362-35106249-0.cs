    class TelegramBotFake : ITelegramBot
    {
        public Message ReturnMessage { get; set; }
        public string SendedMessage { get; set; }
        public Message SendMessage(MessageTarget target, string msg)
        {
            this.SendedMessage = msg;
            return this.ReturnMessage;
        }
    }
