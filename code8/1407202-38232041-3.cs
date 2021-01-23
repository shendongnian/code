    class Book
    {
        public string Name { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        private float _price;
        public float Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value > 30)
                {
                    _price = value * 0.90f;
                }
                else
                {
                    _price = value;
                }
            }
        }
        public Book(string name, string writer, string publisher, float price, string genre)
        {
            Name = name;
            Writer = writer;
            Publisher = publisher;
            Price = price;
            Genre = genre;
        }
    }
