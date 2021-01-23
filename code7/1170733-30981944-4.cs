    private class FontListItem
    {
        public int Size { get; private set; }
        public Font Font { get; private set; }
        public FontListItem(FontFamily family, int size)
        {
            Font = new Font(family, size);
            Size = size;
        }
        public override string ToString()
        {
            if(Font != null)
                return Font.Name + ": " + Size;
            return "[none]: " + Size;
        }
    }
