    public class KeyboardOnKeyEventArgs : KeyboardKeyCodeEventArgs
    {
        public Keycode[] KeyCodes { get; set; }
    }
    
    public class KeyboardKeyCodeEventArgs : EventArgs
    {
        public Keycode PrimaryCode { get; set; }
    }
    
    public class KeyboardOnTextEventArgs : EventArgs
    {
        public ICharSequence Text { get; set; }
    }
    
    public class MyKeyboardListener : Java.Lang.Object, KeyboardView.IOnKeyboardActionListener
    {
        public event EventHandler<KeyboardOnKeyEventArgs> Key;
        public event EventHandler<KeyboardKeyCodeEventArgs> Press;
        public event EventHandler<KeyboardKeyCodeEventArgs> Release;
        public event EventHandler<KeyboardOnTextEventArgs> Text;
        public event EventHandler OnSwipeDown;
        public event EventHandler OnSwipeLeft;
        public event EventHandler OnSwipeRight;
        public event EventHandler OnSwipeUp;
    
        public void OnKey(Keycode primaryCode, Keycode[] keyCodes)
        {
            if (Key != null)
                Key(this, new KeyboardOnKeyEventArgs {
                    KeyCodes = keyCodes,
                    PrimaryCode = primaryCode
                });
        }
    
        public void OnPress(Keycode primaryCode)
        {
            if (Press != null)
                Press(this, new KeyboardKeyCodeEventArgs { PrimaryCode = primaryCode });
        }
    
        public void OnRelease(Keycode primaryCode)
        {
            if (Release != null)
                Release(this, new KeyboardKeyCodeEventArgs { PrimaryCode = primaryCode });
        }
    
        public void OnText(ICharSequence text)
        {
            if (Text != null)
                Text(this, new KeyboardOnTextEventArgs {Text = text});
    
        }
    
        public void SwipeDown()
        {
            if(OnSwipeDown != null)
                OnSwipeDown(this, EventArgs.Empty);
        }
    
        public void SwipeLeft()
        {
            if (OnSwipeLeft != null)
                OnSwipeLeft(this, EventArgs.Empty);
        }
    
        public void SwipeRight()
        {
            if (OnSwipeRight != null)
                OnSwipeRight(this, EventArgs.Empty);
        }
    
        public void SwipeUp()
        {
            if (OnSwipeUp != null)
                OnSwipeUp(this, EventArgs.Empty);
        }
    }
