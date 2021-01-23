    public Vector2 PositionByGrid (int gridWidth, int gridHeight)
        {
            Vector2 result = new Vector2(MouseState.GetState().X, MouseState.GetState().Y);
            result.X = (int)(result.X / gridWidth) * gridWidth;
            result.Y = (int)(result.Y / gridHeight) * gridHeight;
            return result;
        }
