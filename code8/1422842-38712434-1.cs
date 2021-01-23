    class Example
    {
        public ImageCollection Strokes { get { return _strokes; } }
        private readonly ImageCollection _strokes;
       
        public Example()
        {
            _strokes = new ImageCollection();
        }
    }
