    [ContentProperty("Elements")]
    class BitmapImageArray
    {
        private readonly List<ButtonImageStates> _elements = new List<ButtonImageStates>();
        public List<ButtonImageStates> Elements
        {
            get { return _elements; }
        }
    }
    class ButtonImageStates
    {
        public string Key { get; set; }
        public BitmapImage[] StateImages { get; set; }
    }
