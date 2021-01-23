        private void button1_Click(object sender, EventArgs e)
        {
            var width = (int) numericUpDown2.Value;
            var height = (int) numericUpDown3.Value;
            var angle = (float) numericUpDown1.Value;
            var size = new Size(width, height);
            var result = RotatedSettings(angle, size);
            textBox1.Text = String.Format("{0} x {1}", result.Width, result.Height);
        }
        private static Size RotatedSettings(float angle, Size size)
        {
            // setup corner values in array
            var corners = new[]
            { new PointF(0, 0),
              new PointF(size.Width, 0),
              new PointF(0, size.Height),
              new PointF(size.Width, size.Height)};
            // rotate corners
            var xc = corners.Select(p => Rotate(p, (float)angle).X);
            var yc = corners.Select(p => Rotate(p, (float)angle).Y);
            // find the new sizes by subtracting highest from lowest result.
            var widths = xc as IList<float> ?? xc.ToList();
            var newWidth = (int)Math.Abs(widths.Max() - widths.Min());
            var heights = yc as IList<float> ?? yc.ToList();
            var newHeight = (int)Math.Abs(heights.Max() - heights.Min());
            // as we rotate the mid point we need to middle midpoint section and add the outcome to size.
            var midX = ((size.Width / 2) - ((double)newWidth / 2));
            var midY = ((size.Height / 2) - ((double)newHeight / 2));
            return new Size(newWidth + (int)midX, newHeight + (int)midY);
        }
        /// <summary>
        /// Rotates a point around the origin (0,0)
        /// </summary>
        private static PointF Rotate(PointF p, float angle)
        {
            // convert from angle to radians
            var theta = Math.PI * angle / 180;
            return new PointF(
                (float)(Math.Cos(theta) * (p.X) - Math.Sin(theta) * (p.Y)),
                (float)(Math.Sin(theta) * (p.X) + Math.Cos(theta) * (p.Y)));
        }
