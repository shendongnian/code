    private static System.Drawing.PointF convertToPointF(AForge.Point apoint)
        {
            return new PointF(apoint.X,apoint.Y);
        }
        public void DrawData(Blob blob, Bitmap bmp)
        {
            int width = blob.Rectangle.Width;
            int height = blob.Rectangle.Height;
            int area = blob.Area;
            PointF cog = convertToPointF(blob.CenterOfGravity);
        }
