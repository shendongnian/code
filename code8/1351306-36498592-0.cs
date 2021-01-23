        List<RectangleF> GetSubRectangles(Rectangle rect, int cols, int rows)
        {
            List<RectangleF> srex = new List<RectangleF>();
            float w = 1f * rect.Width / cols;
            float h = 1f * rect.Height / rows;
            for (int c = 0; c < cols; c++)
                for (int r = 0; r < rows; r++)
                    srex.Add(new RectangleF(w*c, h*r, w,h ));
            return srex;
        }
