    class TreeMap
    {
        public IEnumerable<Item> Items { get; private set; }
        public TreeMap(params Item[] items) : 
            this(items.AsEnumerable()) { }
        public TreeMap(IEnumerable<Item> items)
        {
            Items = items.OrderByDescending(t => t.Data.Area).ThenByDescending(t => t.Children.Count());
        }
        public Bitmap Draw(int width, int height)
        {
            var bmp = new Bitmap(width + 1, height + 1);
            using (var g = Graphics.FromImage(bmp))
            {
                DrawIn(g, 0, 0, width, height);
                g.Flush();
            }
            return bmp;
        }
        //Private members
    }
