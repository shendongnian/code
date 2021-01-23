    public class ValidationResult
    {
        public ValidationResult()
        {
            MessagesList = new List<string>();
        }
        public bool Validated { get { return MessagesList.Count == 0; } }
        public IList<string> MessagesList { get; set; }
        public string Message
        {
            get
            {
                return string.Join(Environment.NewLine, MessagesList);
            }
        }
    }
