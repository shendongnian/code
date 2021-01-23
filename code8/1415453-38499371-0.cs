    public class VisibilityAttribute : ValidationAttribute
    {
        private bool _isVisible;
        public VisibilityAttribute(bool visible = true)
        {
            _isVisible = visible;
        }
        public bool Status
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
            }
        }
    }
