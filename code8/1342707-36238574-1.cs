    class Widget
    {
        public string Name { get; set; }
        public Widget() 
        {
            Name = string.Empty; // this way someone can call Widget.Name safely
        }
    }
