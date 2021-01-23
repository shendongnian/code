    public Vector2 PositionByGrid (int gridSize)
        {
            Vector2 result = new Vector2(MouseState.GetState().X, MouseState.GetState().Y);
            result.X = (int)(result.X / gridSize) * gridSize;
            result.Y = (int)(result.Y / gridSize) * gridSize;
            return result;
        }
This function will return position of the square. If you want the position in matrix, just put result.X = (int)(result.X / gridSize); instead of result.X = (int)(result.X / gridSize) * gridSize;<br><br>
