    public class TransparentToggleButton : TranspControl
    {
        private Image _normalState;
        private Image _mouseUpState;
        private Image _activateState;
        private bool _state;
        private bool _mouseUnder;
        public event EventHandler StateChanged;
        public bool ToggleState
        {
            get { return _state; }
            set
            {
                _state = value;
                SetImage();
            }
        }
        public void SetImages(Image normalState, Image mouseUpState, Image activateState)
        {
            BackImage = normalState;
            _normalState = normalState;
            _mouseUpState = mouseUpState;
            _activateState = activateState;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                _state = !_state;
                if (StateChanged != null)
                    StateChanged(this, e);
                SetImage();
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _mouseUnder = true;
            SetImage();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouseUnder = false;
            SetImage();
        }
        private void SetImage()
        {
            try
            {
	            if (_state)
	                BackImage = _activateState;
	            else
	                BackImage = _mouseUnder ? _mouseUpState : _normalState;
            }
            catch (Exception)
            {
            	
            }
        }
    }
