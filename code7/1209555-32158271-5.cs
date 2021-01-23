        bool Bdrag;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle Rect = new Rectangle(200, 200 ,40 , 40);
                if(e.Button == MouseButtons.Left)
                {
                    Bdrag = true;
                }
                else
                {
                    Bdrag = false;
                }
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle Rect2 = new Rectangle(250, 250, 40, 40);  
            if(Rect2.Contains(new Point(e.X + Rect2.Location.X, e.Y + Rect2.Location.Y)) && Bdrag == true)
            {
                //is executed when Rect2 has been hit after Rect1
            }          
        }
