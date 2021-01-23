    public class KeyboardHelper 
    {
        public bool IsNumLockPressed
        {
            get { return System.Windows.Input.Keyboard.IsKeyToggled(System.Windows.Input.Key.NumLock); }
        }
    }
