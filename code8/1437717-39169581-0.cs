        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Circle newCircle = new Circle();
            if (e.Button == MouseButtons.Left)
            {
                circle.Name = Count.ToString();
                Location.Offset(-circle.size.Width / 2, -circle.size.Height / 2);
                circle.Location = e.Location;
                circle.CircleShape.Add(new Rectangle(circle.Location, circle.size));
                pictureBox1.Invalidate();
            }
            circle.Circles.Add(newCircle);
            Count++;
        }
