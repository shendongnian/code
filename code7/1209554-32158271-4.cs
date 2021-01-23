        bool Bdrag;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle Rect = new Rectangle(200, 200 ,40 , 40);
            Rectangle Rect2 = new Rectangle(250, 250, 40, 40);
            if(Rect.Contains(new Point(e.X + Rect.Location.X, e.Y + Rect.Location.Y)))
            {
                if(e.Button == MouseButtons.Left)
                {
                    Bdrag = true;
                }
                else
                {
                    Bdrag = false;
                }
            }
            if(Rect2.Contains(new Point(e.X + Rect2.Location.X, e.Y + Rect2.Location.Y)) && Bdrag == true)
            {
                 //is executed when Rect2 has been hit after Rect1
            }
        }
