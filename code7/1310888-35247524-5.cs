    public class Message
    {
        public string Text { get; private set; }
        public int Awesomeness { get; private set; }
        public Message(string Text)
            : this(Text, 1)
        {
        }
        [JsonConstructor]
        public Message(string text, int awesomeness)
        {
            if (awesomeness < 1 || awesomeness > 5)
            {
                throw new ArgumentOutOfRangeException("awesome");
            }
            this.Text = text;
            this.Awesomeness = awesomeness;
        }
    }
