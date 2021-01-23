    class ComboItem
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public ComboItem (string text, int level)
        {  Text = text; Level = level;       }
        public override string ToString()
        {
            return "".PadLeft(Level) + Text;
        }
    }
