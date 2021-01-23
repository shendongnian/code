    public static class Utilities{
        public static void DrawSquare(this Graphics g, Point center, int edgeSize, Pen pen){
            int halfEdge = edgeSize/2;
            Rectangle square = new Rectangle(center.X - halfEdge, center.Y - halfEdge, edgeSize, edgeSize);
            g.DrawRectangle(pen, square);
        }
    }
