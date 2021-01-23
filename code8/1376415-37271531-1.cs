        private void MoveCursorSmooth(Point a, Point b)
        {
            var step = 5;
            var left = Math.Min(a.X, b.X);
            var right = Math.Max(a.X, b.X);
            int width = right - left;
            var top = a.Y;
            var bottom = b.Y;
            int height = bottom - top;
            if (width > height)
            {
                double slope = (double)height / (double)width;
                if (a.X <= b.X) 
                    for (int x = 1; x < width; ++x) 
                    {
                        Cursor.Position = new Point((left + x), (a.Y + ((int)(slope * x + 0.5))));
                        System.Threading.Thread.Sleep(step);
                        Application.DoEvents();
                    }
                else
                    for (int x = 1; x < width; ++x) // xOffset
                    {
                        Cursor.Position = new Point((right - x), (a.Y + ((int)(slope * x + 0.5))));
                        System.Threading.Thread.Sleep(step);
                        Application.DoEvents();
                    }
            }
            else
            {
                
                double slope = (double)width / (double)height;
                if (a.X <= b.X)
                {
                    for (int y = 1; y < height; ++y)
                    {
                        Cursor.Position = new Point((a.X + ((int)(slope * y + 0.5))), (top + y));
                        System.Threading.Thread.Sleep(step);
                        Application.DoEvents();
                    }
                }
                else
                {
                    for (int y = 1; y < height; ++y)
                    {
                        Cursor.Position = new Point((b.X + ((int)(slope * y + 0.5))), (bottom - y));
                        System.Threading.Thread.Sleep(step);
                        Application.DoEvents();
                    }
                }
            }
        }
