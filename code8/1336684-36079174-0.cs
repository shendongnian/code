    [Serializable]
    public sealed class MyCustomStrokes
    {
        public string[][] ColorCodeCollection;
        [NonSerialized()]
        private Dictionary<string, SolidColorBrush> _memo;
        public Brush GetBrush(int i, int j) 
        {
            var code = ColorCodeCollection[i][j];
            if(_memo.ContainsKey(code))
                return _memo[code];
            
            var col = (Color)ColorConverter.ConvertFromString(code);
            var brush = new SolidColorBrush(col);
            brush.Freeze();
            _memo[code] = brush;
            return brush;
        }
    }
