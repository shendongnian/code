    class CBItem
    {
        public string Text { get; private set; }
        public int Value { get; private set; }
        public CBItem(string text, int value)
        {
            Text = text;
            Value = value;
        }
        // This will determine what you see in the combobox
        public override string ToString()
        {
            return Text ?? base.ToString();
        }
    }
