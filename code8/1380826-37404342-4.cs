    class Effects
    {
        private Bitmap _image;
    
        public Effects(Bitmap image)
        {
            _image = image;
        }
    
        public Bitmap Blur(int amount)
        {
            // .. code to perform blur on _image ..
            return _image;
        }
    }
