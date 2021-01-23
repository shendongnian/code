        bool Bdrag;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Point Floater = new Point(e.X, e.Y);
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
            Point Floater = new Point(e.X, e.Y);
            Rectangle Rect2 = new Rectangle(250, 250, 40, 40);  
            if(Rect2.Contains(Floater) && Bdrag == true)
            {
                //is executed when Rect2 has been hit after Rect1
            }          
        }
