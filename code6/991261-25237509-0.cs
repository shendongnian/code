    public static class InputManager
    {
        public static void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }
    
        public static bool IsKeyDown(Keys key) 
        {
            return _currentKeyboardState.IsKeyDown(key);
        }
    
        public static bool IsKeyUp(Keys key)
        {
            return _currentKeyboardState.IsKeyUp(key);
        }
    
        public static bool OnKeyDown(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
        }
    
        public static bool OnKeyUp(Keys key)
        {
            return _currentKeyboardState.IsKeyUp(key) && _previousKeyboardState.IsKeyDown(key);
        }
    
        private static KeyboardState _currentKeyboardState;
        private static KeyboardState _previousKeyboardState;
    }
