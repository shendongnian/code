    class Effects
    {
        private Bitmap _image;
    
        public Effects(Bitmap image)
        {
            _image = image;
        }
    
        public Bitmap Blur(int amount)
        {
            var copy = _image.Clone();
            // .. code to perform blur on copy ..
            return copy;
        }
    }
