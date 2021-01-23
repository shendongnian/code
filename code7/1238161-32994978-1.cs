    class ColorPicker
    {
        public ColorPicker(int colorCount)
        {
            _colors = ColorGenerator.Generate(colorCount).ToArray();
        }
        private readonly Color[] _colors;
        
        public Color StringToColor(string message)
        {
            int someHash = CalculateHashOfStringSomehow(message);
            return _colors[someHash % _colors.Length];
        }
    
        private int CalculateHashOfStringSomehow(string message)
        {
            //TODO: I would not use "message.GetHashCode()" as you are not
            // guaranteed the same value between runs of the program.
        }
    }
