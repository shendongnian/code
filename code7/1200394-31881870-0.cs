    class Spritebatch
    {
        private Graphics Gfx;
        private BufferedGraphics bfgfx;
        private BufferedGraphicsContext cntxt = BufferedGraphicsManager.Current;
        public Spritebatch(Size clientsize, Graphics gfx)
        {
            cntxt.MaximumBuffer = new Size(clientsize.Width + 1, clientsize.Height + 1);
            bfgfx = cntxt.Allocate(gfx, new Rectangle(Point.Empty, clientsize));
            Gfx = gfx;
        }
        public void Begin()
        {
            bfgfx.Graphics.Clear(Color.Black);
        }
        public void Draw(Sprite s)
        {
            bfgfx.Graphics.DrawImageUnscaled(s.Texture, new Rectangle(s.toRec.X - s.rotationOffset.Width,s.toRec.Y - s.rotationOffset.Height,s.toRec.Width,s.toRec.Height));
        }
        public void drawImage(Bitmap b, Rectangle rec)
        {
            bfgfx.Graphics.DrawImageUnscaled(b, rec);
        }
        public void drawImageClipped(Bitmap b, Rectangle rec)
        {
            bfgfx.Graphics.DrawImageUnscaledAndClipped(b, rec);
        }
        public void drawRectangle(Pen p, Rectangle rec)
        {
            bfgfx.Graphics.DrawRectangle(p, rec);
        }
        public void End()
        {
            bfgfx.Render(Gfx);
        }
    }
