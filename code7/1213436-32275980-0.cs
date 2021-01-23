    public class ResistorWithLabel
    {
        public string ComponentName { get; set; }
        public RectangleF Rect { get; set; }
        public float Orientation { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
        public int FontSize { get; set; }
    
        public void Draw(Graphics g)
        {
            Matrix contextMatrix = g.Transform;
            Matrix matrix = new Matrix();
            matrix.RotateAt(Orientation, new PointF((Rect.Left+Rect.Right)/2, (Rect.Top+Rect.Bottom)/2));
    
            SolidBrush polygonBrush = new SolidBrush(BackgroundColor);
            SolidBrush textBrush = new SolidBrush(ForegroundColor);
            Font font = new Font("Courier", FontSize);
    
            PointF TL = new PointF(Rect.Left, Rect.Top);
            PointF TR = new PointF(Rect.Right, Rect.Top);
            PointF BL = new PointF(Rect.Left, Rect.Bottom);
            PointF BR = new PointF(Rect.Right, Rect.Bottom);
            PointF[] points = new PointF[] { BL, TL, TR, BR };
    
            g.Transform = matrix;
            g.FillPolygon(polygonBrush, points);
            g.DrawString(ComponentName, font, textBrush, TL);
            g.Transform = contextMatrix;
        }
    }
    
        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            ResistorWithLabel r1 = new ResistorWithLabel();
            r1.ComponentName = "Resistor 1";
            r1.Rect = new RectangleF(50, 100, 100, 50);
            r1.Orientation = 25;
            r1.BackgroundColor = Color.Blue;
            r1.ForegroundColor = Color.Yellow;
            r1.FontSize = 16;
            r1.Draw(e.Graphics);
    
            ResistorWithLabel r2 = new ResistorWithLabel();
            r2.ComponentName = "Resistor 2";
            r2.Rect = new RectangleF(200, 100, 200, 100);
            r2.Orientation = 75;
            r2.BackgroundColor = Color.Gray;
            r2.ForegroundColor = Color.Orange;
            r2.FontSize = 32;
            r2.Draw(e.Graphics);
        }
