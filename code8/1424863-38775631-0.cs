    public static class ColorImage
    {
        private static readonly Dictionary<UIColor, UIImage> _colorDictionary = new Dictionary<UIColor, UIImage>();
    
        public static UIImage GetColoredImage(UIImage image, UIColor color)
        {
            if(_colorDictionary.ContainsKey(color))
            {
               _colorDictionary.TryGetValue(color, out image);
            }
            else 
            {
                //create the image
                _colorDictionary.Add(color, image);
            }
            return image;
        }
    }
