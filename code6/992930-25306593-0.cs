    public class Line
    {
        Texture2D Texture;
        Color Color;
        public Vector2 PointA;
        public Vector2 PointB;
        float Width;
    
        public Line(Vector2 pointA, Vector2 pointB, float width, Color color, Texture2D texture)
        {
            Texture = texture;
            PointA = pointA;
            PointB = pointB;
            Width = width;
            Color = color;
        }
    
        public void Draw(SpriteBatch spritebatch)
        {
            float angle = (float)Math.Atan2(PointB.Y - PointA.Y, PointB.X - PointA.X);
            float length = Vector2.Distance(PointA, PointB);
            spritebatch.Draw(Texture, PointA, null, Color, angle, Vector2.Zero, new Vector2(length, Width), SpriteEffects.None, 0);
        }
    
    }
