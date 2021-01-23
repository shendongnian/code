    class ColorPicker
    {
        public ColorPicker(int colorCount)
        {
            //The ".Skip(2)" makes it skip pure white and pure black.
            // If you want those two, take out the +2 and the skip.
            _colors = ColorGenerator.Generate(colorCount + 2).Skip(2).ToArray();
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
            // Make up your own algorithom or use a existing one that has a fixed 
            // output for a given input, like MD5.
        }
    }
