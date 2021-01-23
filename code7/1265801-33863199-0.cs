    public class pieceObject : UserControl
    {
        private readonly Color _color;
        public pieceObject(Color color) { _color = color; }
        // Draw the new button. 
        protected override void OnPaint(PaintEventArgs e)
        {
            int width = 15;
            using (SolidBrush newPiece = new SolidBrush(_color))
            {
                e.Graphics.FillEllipse(newPiece, 3, 3, width, width);
            }
        }
    }
