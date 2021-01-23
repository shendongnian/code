    class ListBoxItem
    {
        public string Text { get; set; }
        public string Tag { get; set; }
        public ListBoxItem(string text, string tag)
        {
            this.Text = text;
            this.Tag = tag;
        }
    }
