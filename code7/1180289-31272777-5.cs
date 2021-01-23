    public class MyKeyboardListener : Java.Lang.Object, KeyboardView.IOnKeyboardActionListener
    {
        private readonly Activity _activity;
    
        public MyKeyboardListener(Activity activity) {
            _activity = activity;
        }
    
        public void OnKey(Keycode primaryCode, Keycode[] keyCodes)
        {
            var eventTime = DateTime.Now.Ticks;
            var keyEvent = new KeyEvent(eventTime, eventTime, KeyEventActions.Down, primaryCode, 0);
            _activity.DispatchKeyEvent(keyEvent);
        }
    
        public void OnPress(Keycode primaryCode) { }
        public void OnRelease(Keycode primaryCode) { }
        public void OnText(ICharSequence text) { }
        public void SwipeDown() { }
        public void SwipeLeft() { }
        public void SwipeRight() { }
        public void SwipeUp() { }
    }
