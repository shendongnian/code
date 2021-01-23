     private bool draging = false;
            private Point pointClicked;
            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                if (draging)
                {
                    Point pointMoveTo;
                    pointMoveTo = this.PointToScreen(new Point(e.X, e.Y));
                    pointMoveTo.Offset(-pointClicked.X, -pointClicked.Y);
                    this.Location = pointMoveTo;
                }
            }
            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    draging = true;
                    pointClicked = new Point(e.X, e.Y);
                }
                else
                {
                    draging = false;
                }
            }
            private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                draging = false;
            }
