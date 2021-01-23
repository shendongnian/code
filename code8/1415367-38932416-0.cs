    public partial class STextBox : TextBox
    {
        private bool _allowRfid;
        private static RawInput _kblistener;
        private static bool _handle = false;
        public STextBox()
        {
            _allowRfid = false;
            _kblistener = new RawInput(Handle, true);
            _kblistener.KeyPressed += _kblistener_KeyPressed;
        }
        private void _kblistener_KeyPressed(object sender, RawInputEventArg e)
        {
            if (e.KeyPressEvent.DeviceName == SetUp.RfidDevID) Handling = true;
            else Handling = false;
        }
        public bool AllowRFID
        {
            get { return _allowRfid; }
            set { _allowRfid = value; }
        }
        private static bool Handling
        {
            get { return _handle; }
            set { _handle = value; }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!_allowRfid) e.Handled = Handling;
            base.OnKeyPress(e);
        }
    }
