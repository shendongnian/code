        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();
            // Is the SPACE key down?
            if (newState.IsKeyDown(Keys.Space))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Space))
                {
                    backColor = 
                        new Color(backColor.R, backColor.G, (byte)~backColor.B);
                }
            }
           .
           .
           .
            // Update saved state.
            oldState = newState;
        }
