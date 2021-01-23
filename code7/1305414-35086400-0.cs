    interface IGraphics
    {
        void DrawCircle(int x,int y,int d);
    }
    public class GraphicsAdapter : IGraphics
    {
        private readonly Graphics graphics;
        public GraphicsAdapter(Graphics g)
        {
            this.graphics = g;
        }
        public void DrawCircle(int x, int y, int d)
        {
            graphics.DrawCircle(x, y, d);
        }
    }
