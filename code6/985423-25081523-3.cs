    public interface IKindForm
    {
        void DisplayText( DisplayText t );
    }
    public class DisplayText
    {
        public string Text { get; protected set; }
        public Font Font { get; protected set; }
        public Brush Brush { get; protected set; }
        public Point Point { get; protected set; }
        public DisplayText( string text, Font font, Color color, int x, int y )
        {
            Text = text;
            Font = font;
            Brush = new SolidBrush( color );
            Point = new Point( x, y );
        }
    }
 
