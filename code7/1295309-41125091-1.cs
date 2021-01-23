    public class MenuButton
    {
        #region Properties
        // Some properties that might come is handy
        public Rectangle Bounds { get { return bounds; } }
        public MenuButtonState State { get { return currentState; } }
        // Redundant but handy
        public bool IsClicked { get { return currentState == MenuButtonState.Clicked; } }
        #endregion
        #region Fields
        private Texture2D texture;
        private Vector2 position;
        private Rectangle bounds;
        private MenuButtonState currentState;
        #endregion
        #region Constructor
        public MenuButton(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            // Cast position X and Y to ints for the rectangle's constructor.
            bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            // MenuButton starts off as Released.
            currentState = MenuButtonState.Released;
        }
        #endregion
        #region Update
        public void Update()
        {
            // There are much better ways to impliment button interaction than this 
            // but here is a simple example:
            // If the mouse cursor is on our MenuButton...
            if (InputManager.GetMouseBounds(true).Intersects(bounds))
            {
                // And if the Left mouse button is down...
                if (InputManager.GetIsMouseButtonDown(MouseButton.Left, true))
                {
                    // Then our MenuButton is down!
                    currentState = MenuButtonState.Pressed;
                }
                // Else if the Left mouse button WAS down but isn't any more...
                else if (InputManager.GetIsMouseButtonDown(MouseButton.Left, false))
                {
                    // Then our MenuButton has been clicked!
                    currentState = MenuButtonState.Clicked;
                }
                // Otherwise...
                else
                {
                    // The mouse cursor is simply hovering above our MenuButton!
                    currentState = MenuButtonState.Hovered;
                }
            }
            else
            {
                // If the cursor does not intersect with the MenuButton then just set the state to released.
                currentState = MenuButtonState.Released;
            }
        }
        #endregion
    }
    public enum MenuButtonState
    {
        Released,
        Hovered,
        Pressed,
        Clicked
    }
