        Form form2 = new Form();
        Point mdown = Point.Empty;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mdown = e.Location;
            form2.BackgroundImage = pictureBox1.Image;
            form2.Opacity = 0.5f;
            form2.MaximizeBox = false;
            form2.ControlBox = false;
            form2.Text = "";
            form2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form2.Size = pictureBox1.Image.Size;
            form2.Show();
            Point pt = pictureBox1.PointToScreen(pictureBox1.Location);
            form2.Location = pt;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                form2.Location = pictureBox1.PointToScreen(
                           new Point(e.X -mdown.X, e.Y - mdown.Y ));
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            form2.Hide();
        }
