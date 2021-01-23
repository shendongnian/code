    public static class InputManager
    {
        // #region #endregion tags are a nice way of blockifying code in VS.
        #region Fields
        // Store current and previous states for comparison. 
        private static MouseState previousMouseState;
        private static MouseState currentMouseState;
        // Some keyboard states for later use.
        private static KeyboardState previousKeyboardState;
        private static KeyboardState currentKeyboardState;
        #endregion
        #region Update
        // Update the states so that they contain the right data.
        public static void Update()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }
        #endregion
        #region Mouse Methods
        public static Rectangle GetMouseBounds(bool currentState)
        {
            // Return a 1x1 squre representing the mouse click's bounding box.
            if (currentState)
                return new Rectangle(currentMouseState.X, currentMouseState.Y, 1, 1);
            else
                return new Rectangle(previousMouseState.X, previousMouseState.Y, 1, 1);
        }
        public static bool GetIsMouseButtonUp(MouseButton btn, bool currentState)
        {
            // Simply returns whether the button state is released or not.
            if (currentState)
                switch (btn)
                {
                    case MouseButton.Left:
                        return currentMouseState.LeftButton == ButtonState.Released;
                    case MouseButton.Middle:
                        return currentMouseState.MiddleButton == ButtonState.Released;
                    case MouseButton.Right:
                        return currentMouseState.RightButton == ButtonState.Released;
                }
            else
                switch (btn)
                {
                    case MouseButton.Left:
                        return previousMouseState.LeftButton == ButtonState.Released;
                    case MouseButton.Middle:
                        return previousMouseState.MiddleButton == ButtonState.Released;
                    case MouseButton.Right:
                        return previousMouseState.RightButton == ButtonState.Released;
                }
            return false;
        }
        public static bool GetIsMouseButtonDown(MouseButton btn, bool currentState)
        {
            // This will just call the method above and negate.
            return !GetIsMouseButtonUp(btn, currentState);
        }
        #endregion
        #region Keyboard Methods
        // TODO: Keyboard input stuff goes here.
        #endregion
    }
    // A simple enum for any mouse buttons - could just pass mouseState.ButtonState instead 
    public enum MouseButton
    {
        Left,
        Middle,
        Right
    }
