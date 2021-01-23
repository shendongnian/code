    public class Example
    {
        private int _initialStyle = 0;
    
        public void ApplyStyle()
        {
            _initialStyle = GetWindowLong(...);
            SetWindowLong(..., _initialStyle | /* styles */);
        }
    
        public void RestoreStyle()
        {
            SetWindowLong(..., _initialStyle);
        }
    }
