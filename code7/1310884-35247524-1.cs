    public class Message
    {
        public string Text { get; private set; }
        public int Awesomeness { get; private set; }
        public Message(string Text)
            : this(Text, 1)
        {
        }
        [JsonConstructor]
        public Message(string Text, int Awesomeness)
        {
            if (Awesomeness < 1 || Awesomeness > 5)
            {
                throw new ArgumentOutOfRangeException("awesome");
            }
            this.Text = Text;
            this.Awesomeness = Awesomeness;
        }
    }
